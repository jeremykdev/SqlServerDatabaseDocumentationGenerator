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
            var db = new Database { DatabaseName = "TEST", Description = "OLTP for tests", ObjectId = 0, Parent = null, Schemas = null };
            var schema = new Schema { SchemaId = 1, SchemaName = "Sales", Description = "Sales department", Parent = db };
            db.Schemas = new List<Schema>();
            db.Schemas.Add(schema);

            string actual = schema.CreateDescriptionSqlCommandText();
            string expected = "EXEC sp_addextendedproperty @name='MS_Description' , @value='Sales department' , @level0type='SCHEMA' , @level0name='Sales';";

            Assert.AreEqual(actual, expected, "TestCreateDescriptionSqlCommandTextForSchema failed");

        }
    }
}
