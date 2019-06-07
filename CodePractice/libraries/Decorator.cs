using System;
using System.Collections.Generic;

abstract class LibraryItem{
    private int _numCopies;

    public int Copies{
        get{return _numCopies;}
        set{_numCopies = value;}
    }

    public abstract void Display();
}

class Book : LibraryItem{
    private string _author;
    private string _title;

    public Book(string author, string title, int copies){
        this._author = author;
        this._title = title;
        this.Copies = copies;
    }

    public override void Display(){
        Console.WriteLine("\nBook------");
        Console.WriteLine("Title: {0}", _title);
        Console.WriteLine("Author: {0}", _author);
        Console.WriteLine("Available copies: {0}", Copies);
    }
}

class Video : LibraryItem{
    private string _title;
    private string _director;
    private int _runtime;

    public Video(string title, string director, int runtime, int copies){
        this._title = title;
        this._director = director;
        this._runtime = runtime;
        this.Copies = copies;
    }

    public override void Display(){
        Console.WriteLine("\nVideo------");
        Console.WriteLine("Title: {0}",_title);
        Console.WriteLine("Director: {0}", _director);
        Console.WriteLine("Runtime: {0}", _runtime);
        Console.WriteLine("Available copies {0}", Copies);
    }
}

abstract class Decorator : LibraryItem{
    protected LibraryItem libraryItem;

    public Decorator(LibraryItem library){
        this.libraryItem = library;
    }

    public override void Display(){
        libraryItem.Display();
    }
}

class Borrowable : Decorator{
    protected List<string> borrowers = new List<string>();

    public Borrowable(LibraryItem libraryItem) : base(libraryItem){}

    public void BorrowItem(string name){
        borrowers.Add(name);
        libraryItem.Copies--;
    }

    public void ReturnItem(string name){
        libraryItem.Copies++;
        borrowers.Remove(name);
    }

    public override void Display(){
        base.Display();
        foreach(string borrower in borrowers){
            Console.WriteLine("Checked out by: "+ borrower);
        }
    }
}