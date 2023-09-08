/**
 * MIT License
 * 
 * Copyright (c) 2023 Alexander Perfilyev
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */
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
        public void ValidXmlString()
        {
            Assert.IsTrue(XmlValidator.DetermineXml("<Design><Code>hello world</Code></Design>"));
        }

        [Test]
        public void InvalidXmlString1()
        {
            Assert.IsFalse(XmlValidator.DetermineXml("<Design><Code>hello world</Code></Design><People>"));
        }

        [Test]
        public void InvalidXmlString2()
        {
            Assert.IsFalse(XmlValidator.DetermineXml("<People><Design><Code>hello world</People></Code></Design>"));
        }

        [Test]
        public void InvalidXmlString3()
        {
            Assert.IsFalse(XmlValidator.DetermineXml("<People age=\"1\">hello world</People>"));
        }

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