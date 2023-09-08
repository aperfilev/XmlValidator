

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlValidator
{
    /// <summary>
    /// Provides methods for validating XML strings.
    /// </summary>
    /// <remarks>
    ///   The <see cref="XmlValidator"/> class contains methods for determining whether a given string
    ///   is a valid XML string based on specific criteria:
    ///   - Each starting element must have a corresponding ending element.
    ///   - Nesting of elements within each other must be well nested, meaning start first must end last.
    ///   - A pair of an opening tag and a closing tag is considered matched only if the tag names are identical.
    /// </remarks>
    internal class XmlValidator
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(DetermineXml("<Design><Code>hello world</Code></Design>")); // true
            Console.WriteLine(DetermineXml("<Design><Code>hello world</Code></Design><People>")); // false
            Console.WriteLine(DetermineXml("<People><Design><Code>hello world</People></Code></Design>")); // false
            Console.WriteLine(DetermineXml("<People age=\"1\">hello world</People>")); // false
            Console.ReadKey();
        }

        /// <summary>
        /// Determines whether a given string is a valid XML string.
        /// </summary>
        /// <param name="xml">The XML string to be validated.</param>
        /// <returns>
        ///   <c>true</c> if the input string is a valid XML string; otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        ///   This method checks if the input string satisfies the following criteria for being a valid XML string:
        ///   - Each starting element must have a corresponding ending element.
        ///   - Nesting of elements within each other must be well nested, meaning start first must end last.
        ///   - A pair of an opening tag and a closing tag is considered matched only if the tag names are identical.
        /// </remarks>
        public static bool DetermineXml(string xml)
        {
            Stack<string> tagStack = new Stack<string>();

            int index = 0;
            while (index < xml.Length)
            {
                // Find the next '<' character
                int openTagStart = xml.IndexOf('<', index);

                // If no '<' is found, we've reached the end of the string
                if (openTagStart == -1)
                    break;

                // Find the next '>' character
                int openTagEnd = xml.IndexOf('>', openTagStart);

                // If no '>' is found, the string is not well-formed
                if (openTagEnd == -1)
                    return false;

                // Check if it's a closing tag
                if (xml[openTagStart + 1] == '/')
                {
                    // Extract the tag name from the closing tag
                    string closingTagName = xml.Substring(openTagStart + 2, openTagEnd - openTagStart - 2);

                    // Check if the stack is empty or if the closing tag matches the last opening tag
                    if (tagStack.Count == 0 || tagStack.Peek() != closingTagName)
                        return false;

                    // Pop the opening tag from the stack
                    tagStack.Pop();
                }
                else
                {
                    // Extract the tag name from the opening tag
                    string openingTagName = xml.Substring(openTagStart + 1, openTagEnd - openTagStart - 1);

                    // Push the opening tag onto the stack
                    tagStack.Push(openingTagName);
                }

                // Move the index to the character after the closing '>'
                index = openTagEnd + 1;
            }

            // If there are any remaining opening tags in the stack, the string is not well-formed
            return tagStack.Count == 0;
        }
    }
}
