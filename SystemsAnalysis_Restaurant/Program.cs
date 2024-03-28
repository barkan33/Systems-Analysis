using System;
using System.Collections.Generic;
using System.Text;

namespace SystemsAnalysis_Restaurant
{
    internal class Program
    {
        public static User connectedUser;
        public static List<Dish> dishes;
        public List<Staff> staff;
        public List<Customer> customers;
        public List<Table> tables;
        public List<Order> orders;
        public List<Waiter> waiters;
        public List<Chef> chefs;
        public Admin admin;

        public static Menu menu;

        /*
        public static List<Dish> GenerateDishes()
        {
            Random rand = new Random();
            dishes = new List<Dish>();

            string[] dishNames = { "Spaghetti Carbonara", "Chicken Tikka Masala", "Margherita Pizza", "Caesar Salad", "Sushi Rolls", "Cheeseburger", "Pad Thai", "Fish and Chips", "Mushroom Risotto", "Tiramisu" };
            string[] dishDescriptions = { "Classic Italian pasta dish with bacon and eggs", "Creamy Indian chicken curry with rice",
                "Traditional Italian pizza with tomato, mozzarella, and basil", "Fresh salad with romaine lettuce, croutons," +
                " and Caesar dressing", "Japanese rice rolls filled with fish, vegetables, and avocado", "Juicy beef patty with cheese," +
                " lettuce, and tomato in a bun", "Stir-fried rice noodles with shrimp, tofu, and peanuts", 
                "Deep-fried battered fish served with fries", "Creamy rice dish cooked with mushrooms and parmesan cheese",
                "Classic Italian dessert with layers of coffee-soaked ladyfingers and mascarpone cheese" };

            for (int i = 0; i < dishNames.Length; i++)
            {
                int dishID = i + 1;   
                string dishName = dishNames[i];
                string dishDescription = dishDescriptions[i];
                double dishPrice = rand.Next(10, 50) + rand.NextDouble(); 

                Dish newDish = new Dish(dishID, dishName, dishDescription, dishPrice);
                dishes.Add(newDish);
            }
            dishes =RandomiseDishes(dishes);
            return dishes;
        }*/

        public static List<Table> GenerateTables(int tableAmount)
        {
            List<Table> tables = new List<Table>();

            for (int i = 0; i < tableAmount; i++)
            {
                int tableID = i + 1;
                int tableCapacity = new Random().Next(2, 6);
                Table newTable = new Table(tableID, tableCapacity);
                tables.Add(newTable);
            }
            return tables;
        }

        /*
        public static List<Dish> RandomiseDishes(List<Dish> dishes)
        {
            Random rand = new Random();
            for (int i = 0; i < dishes.Count; i++)
            {
                int randomIndex = rand.Next(i, dishes.Count);
                Dish temp = dishes[i];
                dishes[i] = dishes[randomIndex];
                dishes[randomIndex] = temp;
            }
            return dishes;
        }*/


        static void Main(string[] args)
        {
            List<Staff> staff = new List<Staff>();
            List<Table> tables = GenerateTables(10);
            List<Order> orders = new List<Order>();

            //בחירת שולחן
            // Table selection
            Console.WriteLine("Available tables:");
            // Display available tables (you'll need to implement this logic)

            int selectedTableNumber;
            Table selectedTable = null;
            bool repFlag;
            do
            {
                // אם אתה 
                Console.Write("Enter table number: ");
                selectedTableNumber = int.Parse(Console.ReadLine());
                selectedTable = tables.Find(table => table.GetTableNumber() == selectedTableNumber);
                repFlag = selectedTable == null || selectedTable.GetIsOccupied();
                if (repFlag)
                {
                    Console.WriteLine("Invalid table selection. Please try again.");
                }
            } while (repFlag);

            selectedTable.SetIsOccupied(true);





            //צד לקוח
            {

                menu = new Menu();
                menu.GenerateDishes();
                Console.WriteLine(menu.PrintMenu());
                Console.ReadKey();

                bool continueOrdering = true;
                int dishNumber = 1;

                while (continueOrdering)
                {
                    Console.WriteLine($"Dish #{dishNumber}:");


                    // Dish selection
                    List<Dish> orderedDishes = new List<Dish>();
                    bool continueAddingDishes = true;
                    while (continueAddingDishes)
                    {
                        Console.Write("Enter dish ID or 'done' to finish: ");
                        string input = Console.ReadLine();
                        if (input.ToLower() == "done")
                        {
                            continueAddingDishes = false;
                        }
                        else
                        {
                            int dishID = int.Parse(input);
                            Dish selectedDish = menu.GetDishDetails(dishID); // Implement GetDishDetails in Menu class
                            if (selectedDish != null)
                            {
                                orderedDishes.Add(selectedDish);
                            }
                            else
                            {
                                Console.WriteLine("Invalid dish ID. Please try again.");
                            }
                        }
                        /*
                        while ( )//כל עוד הלקוח רוצה להזמין
                        {
                            //הזמנה מספר X

                            while ()//כל עוד המנה שנבחרה לא זמינה
                            {
                                //בחירת מנה/מנות

                                //בדיקת זמינות מנה?

                            }
                            //כן - אישור הזמנה
                            //X++
                            //תזכורת על מנה מוכנה

                        }
                        //הזמנה נוספת? - לא

                        //הוצאת חשבון

                        while ()//כל עוד לא שילם
                        {
                            //בכנסת פרטים לתשלום

                        }

                        //ביי
                        */
                    }

                    //צד מלצר
                    {
                        while ()
                        {
                            //1. צפיה בהזמנות + סטטוס הזמנה
                            //2. הגשת האוכל המוכן
                            //3. exit
                        }
                    }
                    // צד טבח
                    {
                        while ()
                        {

                            //1. צפיה בהזמנות + סטטוס הזמנה
                            //2. הכנת האוכל + עדכון סטטוס
                            //3. exit

                        }
                    }
                    //צד מנהל
                    {
                        while ()
                        {
                            //1. הוספת מלצר
                            //2. הוספת טבח
                            //3. עדכון תפריט
                            //4. exit

                        }
                    }

                }

            }
        }
