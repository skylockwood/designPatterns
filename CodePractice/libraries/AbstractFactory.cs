using System;

namespace CodePractice{

    abstract class ContinentFactory{
        public abstract Herbivore CreateHerbivore();
        public abstract Carnivore CreateCarnivore();
    }

    class AfricaFactory : ContinentFactory{
        public override Herbivore CreateHerbivore(){
            return new Wildebeest();
        }
        public override Carnivore CreateCarnivore(){
            return new Lion();
        }
    }

    class AmericaFactory : ContinentFactory{
        public override Herbivore CreateHerbivore(){
            return new Bison();
        }
        public override Carnivore CreateCarnivore(){
            return new Wolf();
        } 
    }

    abstract class Herbivore{}
    abstract class Carnivore{
        public abstract void Eat(Herbivore h);
    }

    class Wildebeest : Herbivore{}
    class Lion : Carnivore{
        public override void Eat(Herbivore h){
            Console.WriteLine(GetType().Name + " eats " + h.GetType().Name);
        }
    }

    class Bison : Herbivore{}
    class Wolf : Carnivore{
        public override void Eat(Herbivore h){
            Console.WriteLine(GetType().Name + " eats " + h.GetType().Name);
        }
    }

    class AnimalWorld{ 
        private Herbivore _herbivore;
        private Carnivore _carnivore;

        public AnimalWorld(ContinentFactory factory){
            _herbivore = factory.CreateHerbivore();
            _carnivore = factory.CreateCarnivore();
        }

        public void RunFoodChain(){
            _carnivore.Eat(_herbivore);
        }
    }
}