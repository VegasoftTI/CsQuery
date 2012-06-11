﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CsQuery.Implementation;

namespace CsQuery
{

    public interface IDomObject: IDomNode
    {
        // To simulate the way the real DOM works, most properties/methods of things directly in the DOM
        // are part of a common interface, even if they do not apply.

        IDomDocument Document { get; }
        IDomContainer ParentNode { get; }
        IDomObject this[int index] { get; }
        string this[string attribute] { get; set; }

        string Id { get; set; }

        /// <summary>
        /// The same as NodeName, but not mapped to uppercase (e.g. exactly as parsed)
        /// </summary>
        string TagName { get; }

        DomAttributes Attributes { get; }
        CSSStyleDeclaration Style { get; }
        string ClassName { get; set; }

        string Value { get; set; }
        string DefaultValue { get; set; }

        string InnerHTML { get; set; }
        string InnerText { get; set; }

        void AppendChild(IDomObject element);
        void RemoveChild(IDomObject element);
        void InsertBefore(IDomObject newNode, IDomObject referenceNode);
        void InsertAfter(IDomObject newNode, IDomObject referenceNode);

        IDomObject FirstChild { get; }
        IDomElement FirstElementChild { get; }
        IDomObject LastChild { get; }
        IDomElement LastElementChild { get; }
        IDomObject NextSibling { get; }
        IDomObject PreviousSibling { get; }
        IDomElement NextElementSibling { get; }
        IDomElement PreviousElementSibling { get; }

        void SetAttribute(string name);
        void SetAttribute(string name, string value);
        string GetAttribute(string name);
        string GetAttribute(string name, string defaultValue);
        bool TryGetAttribute(string name, out string value);
        bool HasAttribute(string name);
        bool RemoveAttribute(string name);

        /// <summary>
        /// Returns true if this node has any attributes
        /// </summary>
        bool HasAttributes { get; }

        /// <summary>
        /// Returns true if this node has CSS classes
        /// </summary>
        bool HasClasses { get; }

        /// <summary>
        /// Returns true if this node has styles
        /// </summary>
        bool HasStyles { get; }

        bool Selected { get; }
        bool Checked { get; set; }
        bool ReadOnly { get; set; }

        /// <summary>
        /// The type of attribute
        /// </summary>
        string Type { get; set; }

        // Nonstandard elements
        bool InnerHtmlAllowed { get; }
        bool InnerTextAllowed { get; }

        int DescendantCount();
        int Depth { get; }
        int Index { get; }
        string PathID { get; }
        string Path { get; }

        // Wrap this node in a CQ object
        CQ Cq();
        new IDomObject Clone();
    }

    public interface IDomObject<out T> : IDomObject
    {
        new T Clone();
    }
}
