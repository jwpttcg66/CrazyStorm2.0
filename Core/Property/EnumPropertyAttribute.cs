﻿/*
 * The MIT License (MIT)
 * Copyright (c) StarX 2016 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrazyStorm.Core
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    sealed class EnumPropertyAttribute : PropertyAttribute
    {
        Type type;
        public EnumPropertyAttribute(Type enumType)
        {
            type = enumType;
        }
        public override bool IsLegal(string newValue, out object value)
        {
            value = null;
            newValue = newValue.Trim();
            bool result = Enum.IsDefined(type, newValue);
            if (result)
            {
                value = Enum.Parse(type, newValue);
                return true;
            }
            return false;
        }
    }
}
