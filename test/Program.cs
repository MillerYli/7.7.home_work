using System;
using System.Runtime.CompilerServices;


namespace Project
{
    class Programm
    {
        static void Main(string[] args)
        {
            //Идентификатор заказа
            Identifier<string> id_two = new Identifier<string>();
            id_two.id = "SLE-889";
            string number2 = id_two.id;

            Identifier<string> displayId = new Identifier<string>();
            displayId.DisplayID(number2);
            
            Order order = new Order();
            Product product = new Product();
            Delivery delivery = new Delivery();
            Persona persona = new Persona();
            
            //На чье имя оформлен заказ
            persona.DisplayName();
            //Тип доставки
            Console.Write("Тип доставки: ");
            delivery.TypeDelivery("pick");
            //Описание заказа
            order.DisplayDescription();
            //Имя и описание продукта
            product.DisplayProduct();
            product.DisplayDescription();

            
            

        }
    }
}


class Identifier<Tid>
{
    public Tid id;

    public void DisplayID(Tid idnew)
    {
        Console.WriteLine($"ID вашего заказа: {idnew}");
    }
}
class Delivery : Persona
{
    Persona persona1 = new Persona();
    public void TypeDelivery(string type)
    {
        if (type == "home")
        {
            HomeDelivery homeDelivery = new HomeDelivery();
            homeDelivery.Home();
            homeDelivery.DisplayNameCourier("Иванов Иван");
            homeDelivery.ConnectionWithYou(persona1.phone);

        }
        else if (type == "pick")
        {
            PickPointDelivery pickPointDelivery = new PickPointDelivery();
            pickPointDelivery.Pick();
            pickPointDelivery.ConnectionWithYou(persona1.phone);

            
        }
        else
        {
            ShopDelivery shopDelivery = new ShopDelivery();
            shopDelivery.Shop();
            shopDelivery.ConnectionWithYou(persona1.phone);
        }
    }
        
}

class HomeDelivery : Delivery
{
    public void Home()
    {
        Console.WriteLine("Доставка курьером");
    }

    public void DisplayNameCourier(string nameCourier)
    {
        Console.WriteLine($"Ваш заказ доставит: {nameCourier}");
    }

    public void ConnectionWithYou(long phone)
    {
        Console.WriteLine($"С Вами свяжуться по номеру: {phone}");
    }
}

class PickPointDelivery : Delivery
{
    private string adressPick = "г.Москва";
    public void Pick()
    {
        Console.WriteLine($"Доставка в пункт выдачи по адресу: {adressPick}");
    }
    public void ConnectionWithYou(long phone)
    {
        Console.WriteLine($"С Вами свяжуться по номеру: {phone}");
    }

}

class ShopDelivery : Delivery
{
    private string adressShop = "г.Москва";
    public void Shop()
    {
        Console.WriteLine($"Доставка в магазин по адресу: {adressShop}");
    }
    public void ConnectionWithYou(long phone)
    {
        Console.WriteLine($"С Вами свяжуться по номеру: {phone}");
    }
}


class Persona
{
    string name = "Yulia";
    public long phone = 89689689000;
    public void DisplayName()
    {
        Console.WriteLine($"Доставка на имя: {name}");
    }
}
class Order : Delivery
{
    public string Description = "Описание";

    public void DisplayDescription()
    {
       
        Console.WriteLine($"Описание вашего заказа: {Description}");
    }
    public virtual void DisplayProduct()
    {
        Console.WriteLine($"Вы заказали: ");
    }

}



class Product : Order
{
    private string description = "Описание продукта";
    public string nameProduct = "Крем";
    public void DisplayDescription()    
    {
        Console.WriteLine($"Описание продукта: {description}");
    }

    public override void DisplayProduct()
    {
        //this.nameProduct = nameProduct;
        Console.WriteLine($"Ваш заказ: {nameProduct}");

    }
}