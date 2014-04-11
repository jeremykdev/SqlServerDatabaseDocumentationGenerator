//This file comes from the Be.Timvw.Framework
//The Be.Timvw.Framework was created by Tim Van Wassenhove and is distributed under the Apache 2.0 license.
//http://betimvwframework.codeplex.com/

using System;
using System.ComponentModel;

namespace Be.Timvw.Framework.ComponentModel
{
    public static class PropertyDescriptorHelper
    {
        public static PropertyDescriptor Get(object component, string propertyName)
        {
            PropertyDescriptor propertyDescriptor;
            if (TryGet(component, propertyName, out propertyDescriptor))
            {
                return propertyDescriptor;
            }

            throw new ArgumentException(string.Format("The property '{0}' was not found.", propertyName));
        }

        public static bool TryGet(object component, string propertyName, out PropertyDescriptor propertyDescriptor)
        {
            PropertyDescriptorCollection propertyDescriptors = TypeDescriptor.GetProperties(component);
            foreach (PropertyDescriptor aPropertyDescriptor in propertyDescriptors)
            {
                if (aPropertyDescriptor.Name == propertyName)
                {
                    propertyDescriptor = aPropertyDescriptor;
                    return true;
                }
            }

            propertyDescriptor = null;
            return false;
        }
    }
}
