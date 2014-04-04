using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using net.datacowboy.SqlServerDatabaseDocumentationGenerator.Model;
using net.datacowboy.SqlServerDatabaseDocumentationGenerator.Utility;

namespace SqlServerDatabaseDocumentationGeneratorTest
{
    [TestClass]
    public class TestExtendedPropertyExtension
    {

        private Database getTestDatabase()
        {
            var db = new Database { DatabaseName = "TEST", Description = "OLTP for tests", ObjectId = 0, Parent = null, Schemas = null };
         
            var schema = new Schema { SchemaId = 1, SchemaName = "Sales", Description = "Sales department", Parent = db };
            db.Schemas = new List<Schema>();
            db.Schemas.Add(schema);

            var view = new View { ViewId = 20, ViewName = "vTest", Description = "Sample view", Parent = schema };
            schema.Views = new List<View>();
            schema.Views.Add(view);

            return db;
        }

        [TestMethod]
        public void TestCreateDescriptionSqlCommandTextForDatabase()
        {
            var db = new Database { DatabaseName = "TEST", Description = "OLTP for tests", ObjectId = 0, Parent = null, Schemas = null };

            string actual = db.CreateDescriptionSqlCommandText();
            string expected = "EXEC sp_addextendedproperty @name='MS_Description' , @value='OLTP for tests';";

            Assert.AreEqual(actual, expected, "TestCreateDescriptionSqlCommandTextForDatabase failed");

        }

        [TestMethod]
        public void TestCreateDescriptionSqlCommandTextForSchema()
        {
            var db = this.getTestDatabase();
            var schema = db.Schemas[0];

            string actual = schema.CreateDescriptionSqlCommandText();
            string expected = "EXEC sp_addextendedproperty @name='MS_Description' , @value='Sales department' , @level0type='SCHEMA' , @level0name='Sales';";

            Assert.AreEqual(actual, expected, "TestCreateDescriptionSqlCommandTextForSchema failed");

        }

        [TestMethod]
        public void TestCreateDescriptionSqlCommandTextForView()
        {
            var db = this.getTestDatabase();
            var view = db.Schemas[0].Views[0];

            string actual = view.CreateDescriptionSqlCommandText();
            string expected = "EXEC sp_addextendedproperty @name='MS_Description' , @value='Sample view' , @level0type='SCHEMA' , @level0name='Sales' , @level1type='VIEW' , @level1name='vTest';";

            Assert.AreEqual(actual, expected, "TestCreateDescriptionSqlCommandTextForView failed");

        }
    }
}
