﻿using System;
using Xunit;
using Xunit.Extensions;

namespace Humanizer.Tests
{
    public class DehumanizeToEnumTests
    {
        [Fact]
        public void ThrowsForNonEnums()
        {
            Assert.Throws<ArgumentException>(() => EnumTestsResources.CustomDescription.DehumanizeTo<DummyStructWithEnumInterfaces>());
            Assert.Throws<ArgumentException>(() => EnumTestsResources.CustomDescription.DehumanizeTo(typeof(DummyStructWithEnumInterfaces)));
        }

        [Fact]
        public void ThrowsForEnumNoMatch()
        {
            Assert.Throws<NoMatchFoundException>(() => EnumTestsResources.CustomDescription.DehumanizeTo<DummyEnum>());
            Assert.Throws<NoMatchFoundException>(() => EnumTestsResources.CustomDescription.DehumanizeTo(typeof(DummyEnum)));
        }

        [Fact]
        public void CanReturnNullForEnumNoMatch()
        {
            Assert.Null(EnumTestsResources.CustomDescription.DehumanizeTo(typeof(DummyEnum), OnNoMatch.ReturnsNull));
        }

        [Fact]
        public void HonorsDescriptionAttribute()
        {
            Assert.Equal(EnumUnderTest.MemberWithDescriptionAttribute, EnumTestsResources.CustomDescription.DehumanizeTo<EnumUnderTest>());
            Assert.Equal(EnumUnderTest.MemberWithDescriptionAttribute, EnumTestsResources.CustomDescription.DehumanizeTo(typeof(EnumUnderTest)));
        }

        [Fact]
        public void DehumanizeMembersWithoutDescriptionAttribute()
        {
            Assert.Equal(EnumUnderTest.MemberWithoutDescriptionAttribute, EnumTestsResources.MemberWithoutDescriptionAttributeSentence.DehumanizeTo<EnumUnderTest>());
            Assert.Equal(EnumUnderTest.MemberWithoutDescriptionAttribute, EnumTestsResources.MemberWithoutDescriptionAttributeSentence.DehumanizeTo(typeof(EnumUnderTest)));
        }

        [Theory]
        [InlineData(EnumTestsResources.MemberWithoutDescriptionAttributeTitle, EnumUnderTest.MemberWithoutDescriptionAttribute)]
        [InlineData(EnumTestsResources.MemberWithoutDescriptionAttributeLowerCase, EnumUnderTest.MemberWithoutDescriptionAttribute)]
        [InlineData(EnumTestsResources.MemberWithoutDescriptionAttributeSentence, EnumUnderTest.MemberWithoutDescriptionAttribute)]
        public void IsCaseInsensitive(string input, EnumUnderTest expectedEnum)
        {
            Assert.Equal(expectedEnum, input.DehumanizeTo<EnumUnderTest>());
            Assert.Equal(expectedEnum, input.DehumanizeTo(typeof(EnumUnderTest)));
        }

        [Fact]
        public void AllCapitalMembersAreReturnedAsIs()
        {
            Assert.Equal(EnumUnderTest.ALLCAPITALS, EnumUnderTest.ALLCAPITALS.ToString().DehumanizeTo<EnumUnderTest>());
            Assert.Equal(EnumUnderTest.ALLCAPITALS, EnumUnderTest.ALLCAPITALS.ToString().DehumanizeTo(typeof(EnumUnderTest)));
        }

        struct DummyStructWithEnumInterfaces : IComparable, IFormattable, IConvertible
        {
            public int CompareTo(object obj)
            {
                throw new NotImplementedException();
            }

            public string ToString(string format, IFormatProvider formatProvider)
            {
                throw new NotImplementedException();
            }

            public TypeCode GetTypeCode()
            {
                throw new NotImplementedException();
            }

            public bool ToBoolean(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public char ToChar(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public sbyte ToSByte(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public byte ToByte(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public short ToInt16(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public ushort ToUInt16(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public int ToInt32(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public uint ToUInt32(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public long ToInt64(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public ulong ToUInt64(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public float ToSingle(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public double ToDouble(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public decimal ToDecimal(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public DateTime ToDateTime(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public string ToString(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public object ToType(Type conversionType, IFormatProvider provider)
            {
                throw new NotImplementedException();
            }
        }

        enum DummyEnum
        {
            First,
            Second
        }
    }

    

}
