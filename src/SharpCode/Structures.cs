using System.Collections.Generic;
using Optional;

namespace SharpCode
{
    /// <summary>
    /// Represents the access modifier of a C# structure.
    /// </summary>
    public enum AccessModifier
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        None,
        Private,
        Internal,
        Protected,
        Public,
        PrivateInternal,
        ProtectedInternal,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    }

    internal class Field
    {
        public AccessModifier AccessModifier { get; set; } = AccessModifier.Private;

        public bool IsReadonly { get; set; }

        public string? Type { get; set; }

        public string? Name { get; set; }

        public Option<string?> Summary { get; set; } = Option.None<string?>();
    }

    internal class Property
    {
        public AccessModifier AccessModifier { get; set; } = AccessModifier.Public;

        public bool IsStatic { get; set; } = false;

        public string? Type { get; set; }

        public string? Name { get; set; }

        public Option<string?> Summary { get; set; } = Option.None<string?>();

        public Option<string> DefaultValue { get; set; } = Option.None<string>();

        public Option<string?> Getter { get; set; } = Option.Some<string?>(null);

        public Option<string?> Setter { get; set; } = Option.Some<string?>(null);
    }

    internal class Parameter
    {
        public string? Type { get; set; }

        public string? Name { get; set; }

        public string? ReceivingMember { get; set; }
    }

    internal class Constructor
    {
        public AccessModifier AccessModifier { get; set; } = AccessModifier.Public;

        public bool IsStatic { get; set; } = false;

        public string? ClassName { get; set; }

        public Option<string?> Summary { get; set; } = Option.None<string?>();

        public List<Parameter> Parameters { get; } = new List<Parameter>();

        public Option<IEnumerable<string>> BaseCallParameters { get; set; } = Option.None<IEnumerable<string>>();
    }

    internal class Class
    {
        public AccessModifier AccessModifier { get; set; } = AccessModifier.Public;

        public bool IsStatic { get; set; } = false;

        public string? Name { get; set; }

        public Option<string?> Summary { get; set; } = Option.None<string?>();

        public Option<string> InheritedClass { get; set; } = Option.None<string>();

        public List<string> ImplementedInterfaces { get; } = new List<string>();

        public List<Field> Fields { get; } = new List<Field>();

        public List<Property> Properties { get; } = new List<Property>();

        public List<Constructor> Constructors { get; } = new List<Constructor>();
    }

    internal class Struct
    {
        public AccessModifier AccessModifier { get; set; } = AccessModifier.Public;

        public string? Name { get; set; }

        public Option<string?> Summary { get; set; } = Option.None<string?>();

        public List<string?> ImplementedInterfaces { get; } = new List<string?>();

        public List<Constructor> Constructors { get; } = new List<Constructor>();

        public List<Field> Fields { get; } = new List<Field>();

        public List<Property> Properties { get; } = new List<Property>();
    }

    internal class Interface
    {
        public AccessModifier AccessModifier { get; set; } = AccessModifier.Public;

        public string? Name { get; set; }

        public Option<string?> Summary { get; set; } = Option.None<string?>();

        public List<string> ImplementedInterfaces { get; } = new List<string>();

        public List<Property> Properties { get; } = new List<Property>();
    }

    internal class EnumerationMember
    {
        public string? Name { get; set; }

        public Option<int> Value { get; set; } = Option.None<int>();

        public Option<string?> Summary { get; set; } = Option.None<string?>();
    }

    internal class Enumeration
    {
        public AccessModifier AccessModifier { get; set; } = AccessModifier.Public;

        public string? Name { get; set; }

        public Option<string?> Summary { get; set; } = Option.None<string?>();

        public bool IsFlag { get; set; }

        public List<EnumerationMember> Members { get; } = new List<EnumerationMember>();
    }

    internal class Namespace
    {
        public string? Name { get; set; }

        public List<string> Usings { get; } = new List<string>();

        public List<Class> Classes { get; } = new List<Class>();

        public List<Struct> Structs { get; } = new List<Struct>();

        public List<Interface> Interfaces { get; } = new List<Interface>();

        public List<Enumeration> Enums { get; } = new List<Enumeration>();
    }
}
