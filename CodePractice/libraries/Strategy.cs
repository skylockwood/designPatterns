using System;
using System.Collections.Generic;

abstract class SortStrategy{
    public abstract void Sort(List<string> list);
}

class QuickSort : SortStrategy{
    public override void Sort(List<string> list){
        list.Sort();
        Console.WriteLine("QuickSorted list ");
    }
}

class ShellSort : SortStrategy{
    public override void Sort(List<string> list){
        Console.WriteLine("ShellSorted list ");
    }
}

class MergeSort : SortStrategy{
    public override void Sort(List<string> list){
        Console.WriteLine("MergeSorted list ");
    }
}

class SortedList{
    private List<string> _list = new List<string>();
    private SortStrategy _sortstrategy;

    public void SetSortStrategy(SortStrategy sortstrategy){
        this._sortstrategy = sortstrategy;
    }

    public void Add(string name){
        _list.Add(name);
    }

    public void Sort(){
        _sortstrategy.Sort(_list);

        foreach(string name in _list){
            Console.WriteLine(" "+ name);
        }
        Console.WriteLine();
    }
}