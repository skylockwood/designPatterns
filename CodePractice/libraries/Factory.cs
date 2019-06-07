using System;
using System.Collections.Generic;

abstract class Page{}
class Title : Page{}
class Introduction : Page{}
class Procedure : Page{}
class Findings : Page{}
class Summary : Page{}
class Education : Page{}
class Experience : Page{}
class Skills : Page{}

abstract class Document{
    private List<Page> _pages = new List<Page>();

    public Document(){
        this.CreatePages();
    }

    public abstract void CreatePages();

    public List<Page> Pages{
        get{
            return _pages;
        }
    }
}
class Report : Document{
    public override void CreatePages(){
        Pages.Add(new Title());
        Pages.Add(new Introduction());
        Pages.Add(new Procedure());
        Pages.Add(new Findings());
        Pages.Add(new Summary());
    }
}
class Resume : Document{
    public override void CreatePages(){
        Pages.Add(new Education());
        Pages.Add(new Skills());
        Pages.Add(new Experience());
    }
}