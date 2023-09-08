using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace XmlValidator
{
    [TestFixture]
    public class XmlValidatorTests
    {
        [Test]
        public void EmptyXmlStringIsValid()
        {
            Assert.IsTrue(XmlValidator.DetermineXml(""));
        }

        [Test]
        public void NonASCIIEncodingIsValid()
        {
            Assert.IsTrue(XmlValidator.DetermineXml("<Text>Привет, мир!</Text>"));
        }

        [Test]
        public void MismatchedTagsAreInvalid()
        {
            Assert.IsFalse(XmlValidator.DetermineXml("<Book><Title>XML Basics</Book></Title>"));
        }

        [Test]
        public void InvalidCharactersAreInvalid()
        {
            Assert.IsFalse(XmlValidator.DetermineXml("<Product>&</Product>"));
        }

        [Test]
        public void MissingClosingTagIsInvalid()
        {
            Assert.IsFalse(XmlValidator.DetermineXml("<Order><Item>Item 1</Item><Item>Item 2"));
        }
    }
}