using System;
using System.Collections.Generic;

abstract class DrawingElement{
    protected string _name;

    public DrawingElement(string name){
        this._name = name;
    }

    public abstract void Add(DrawingElement d);
    public abstract void Remove(DrawingElement d);
    public abstract void Display(int indent);
}

class PrimitiveElement : DrawingElement{
    public PrimitiveElement(string name) : base(name){}

    public override void Add(DrawingElement d){
        Console.WriteLine("Cannot add to a PrimitiveElement");
    }

    public override void Remove(DrawingElement d){
        Console.WriteLine("Cannot remove from a PrimitiveElement");
    }
    public override void Display(int indent){
        Console.WriteLine(new String('-', indent)+ " " + _name);
    }
}

class CompositeElement : DrawingElement{
    private List<DrawingElement> elements = new List<DrawingElement>();

    public CompositeElement(string name) : base(name){}

    public override void Add(DrawingElement d){
        elements.Add(d);
    }

    public override void Remove(DrawingElement d){
        elements.Remove(d);
    }

    public override void Display(int indent){
        Console.WriteLine(new String('-', indent)+ "+ " + _name);

        foreach(DrawingElement d in elements){
            d.Display(indent + 2);
        }
    }
}