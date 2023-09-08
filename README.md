# XML Validator

The `XmlValidator` class provides methods for validating XML strings according to specific criteria. It checks whether a given string is a valid XML string based on the following rules:

- Each starting element must have a corresponding ending element.
- Nesting of elements within each other must be well nested, meaning start first must end last.
- A pair of an opening tag and a closing tag is considered matched only if the tag names are identical.

## Usage

To use the `XmlValidator` class, follow these steps:

1. Include the `XmlValidator.cs` file in your project.

2. Create an instance of the `XmlValidator` class or use the static methods directly.

3. Call the `DetermineXml` method, passing your XML string as an argument. This method will return `true` if the input string is a valid XML string according to the specified rules; otherwise, it will return `false`.

### Example

```csharp
using System;

class Program
{
    static void Main(string[] args)
    {
        string xmlString = "<Design><Code>hello world</Code></Design>";
        bool isValidXml = XmlValidator.DetermineXml(xmlString);

        if (isValidXml)
        {
            Console.WriteLine("The XML string is valid.");
        }
        else
        {
            Console.WriteLine("The XML string is not valid.");
        }
    }
}
