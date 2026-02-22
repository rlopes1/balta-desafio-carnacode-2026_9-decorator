// DESAFIO: Sistema de Pedidos de Cafeteria
// PROBLEMA: Uma cafeteria oferece bebidas base (Café, Cappuccino, Chá) e múltiplos complementos
// (Leite, Chocolate, Chantilly, Caramelo). O código atual cria uma classe para cada combinação
// possível, resultando em explosão de classes e código duplicado

using System;

namespace DesignPatternChallenge
{
    // Contexto: Sistema de pedidos que precisa calcular preços e descrições
    // com múltiplas combinações de bebidas e complementos
    
    // Bebidas base
    
    public interface IBebida
    {
        decimal GetCost();
        string GetDescription();
    }

    public class Espresso : IBebida
    {
        public decimal GetCost()
        {
            return 3.50m;
        }

        public string GetDescription()
        {
            return "Espresso";
        }
    }

    public class Cappuccino : IBebida
    {
        public decimal GetCost()
        {
            return 4.50m;
        }

        public string GetDescription()
        {
            return "Cappuccino";
        }
    }

    public class Cha : IBebida
    {
        public decimal GetCost()
        {
            return 2.50m;
        }

        public string GetDescription()
        {
            return "Chá";
        }
    }

    public abstract class BebidaDecorator: IBebida
    {
        protected readonly IBebida _bebida;

        public BebidaDecorator(IBebida bebida)
        {
            _bebida = bebida;
        }

        public virtual decimal GetCost() => _bebida.GetCost();
        public virtual string GetDescription() => _bebida.GetDescription();
    }

    
        

    

    
    public class LeiteDecorator : BebidaDecorator
    {

        public LeiteDecorator(IBebida bebida) : base(bebida)
        {
        }

        public override decimal GetCost()
        {
            return base.GetCost() + 0.50m;
        }

        public override string GetDescription()
        {
            return base.GetDescription() + " com Leite";
        }
    }

  

    public class ChocolateDecorator : BebidaDecorator
    {

        public ChocolateDecorator(IBebida bebida) : base(bebida)
        {
        }

        public override decimal GetCost()
        {
            return base.GetCost() + 0.70m;
        }

        public override string GetDescription()
        {
            return base.GetDescription() + " com Chocolate";
        }
    }

    public class ChantillyDecorator : BebidaDecorator
    {

        public ChantillyDecorator(IBebida bebida) : base(bebida)
        {
        }

        public override decimal GetCost()
        {
            return base.GetCost() + 1.00m;
        }

        public override string GetDescription()
        {
            return base.GetDescription() + " com Chantilly";
        }
    }

    public class CarameloDecorator : BebidaDecorator
    {

        public CarameloDecorator(IBebida bebida) : base(bebida)
        {
        }

        public override decimal GetCost()
        {
            return base.GetCost() + 0.80m;
        }

        public override string GetDescription()
        {
            return base.GetDescription() + " com Caramelo";
        }
    }

  

    

 

    

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Sistema de Pedidos - Cafeteria ===\n");

            // Abordagem 1: Classes específicas (explosão combinatória)
            Console.WriteLine("--- Pedidos com classes específicas ---");
            
            IBebida cafe1 = new Espresso();
            Console.WriteLine($"{cafe1.GetDescription()}: R$ {cafe1.GetCost():N2}");

            IBebida cafe2 = new LeiteDecorator(cafe1);
            Console.WriteLine($"{cafe2.GetDescription()}: R$ {cafe2.GetCost():N2}");

            IBebida cafe3 = new ChocolateDecorator(cafe2);
            Console.WriteLine($"{cafe3.GetDescription()}: R$ {cafe3.GetCost():N2}");

            IBebida cafe4 = new Cappuccino();
            cafe4 = new LeiteDecorator(cafe4);
            cafe4 = new ChocolateDecorator(cafe4);
            cafe4 = new ChantillyDecorator(cafe4);
            Console.WriteLine($"{cafe4.GetDescription()}: R$ {cafe4.GetCost():N2}");

      
            IBebida cha = new Cha();
            cha = new LeiteDecorator(cha);
            cha = new ChocolateDecorator(cha);
            cha = new ChantillyDecorator(cha);
            cha = new CarameloDecorator(cha);
            Console.WriteLine($"{cha.GetDescription()}: R$ {cha.GetCost():N2}");

           

            // Perguntas para reflexão:
            // - Como adicionar comportamento a um objeto dinamicamente?
            // - Como combinar múltiplos comportamentos sem criar classes para cada combinação?
            // - Como manter a interface compatível ao adicionar funcionalidades?
            // - Como permitir que complementos sejam adicionados em tempo de execução?
        }
    }
}
