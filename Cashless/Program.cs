using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Cashless
{
    class Program
    {
        static void Main(string[] args)
        {
            char customerContinue = ' ';
            int itemNameLenght,
                totalItems = 0,
                cardNumber,
                carNumberLenght,
                firstThreeNumber,
                lastNumber,
                remainder;
            const int MAX = 8,
                      MIN = 1,
                      DIGIT = 4;
            string inputItemName,
                   inputItemPrice,
                   inputAnswer,
                   itemName,
                   inputstring,
                   inputCardNumber,
                   answer;
            double itemPrice,
                   discount = 0,
                   totalPrice = 0,
                   discountAmount = 0,
                   FinalPrice = 0;
            bool verifyPurchase = false,
                 checkItemPrice = false,
                 checkCustomerContinue = false,
                 checkPurchase,
                 verifyItem,
                 verifyPrice,
                 verifyCustomer,
                 checkCardNumber;
            const double notOwing = 0,
                         TOTALDISCOUNT1 = 100,
                         TOTALDISCOUNT2 = 300,
                         DISCOUNT1 = 1.5,
                         DISCOUNT2 = 2.5;
            WriteLine("Hello welcome!");
            while (customerContinue != 'q' && customerContinue != 'Q')
            {
                customerContinue = ' ';
                while (verifyPurchase == false)
                {
                    verifyItem = false;
                    while (verifyItem == false)
                    {
                        Write("Please enter your item name: ");
                        inputItemName = ReadLine();
                        itemName = inputItemName;
                        itemNameLenght = itemName.Length;

                        if (itemNameLenght >= MAX || itemNameLenght < MIN)
                        {
                            WriteLine("{0} is an invalid item. Please enter again.. ", itemName);
                            verifyItem = false;
                        }
                        else
                        {
                            //WriteLine("{0} is valid", itemName);
                            totalItems += 1;
                            verifyItem = true;
                            inputItemName = null;
                        }
                    }//end of loop verify items

                    verifyPrice = false;
                    while (verifyPrice == false)
                    {
                        Write("Please enter price of your item: ");
                        inputItemPrice = ReadLine();
                        checkItemPrice = double.TryParse(inputItemPrice, out itemPrice);
                        if (checkItemPrice == false || itemPrice <= 0)
                        {
                            WriteLine("{0} is an invalid price. Please enter again ..", itemPrice);
                            verifyItem = false;
                        }//end of if
                        else
                        {
                            //WriteLine("{0} is valid", itemPrice);
                            totalPrice += itemPrice;
                            verifyPrice = true;
                            inputItemPrice = null;
                        }//end pf else

                    }//end of loop verify price

                    checkPurchase = false;
                    //verify 
                    while (checkPurchase == false)
                    {
                        Write("Do you want to add more items? Please answer Y/N: ");
                        inputAnswer = ReadLine();
                        answer = inputAnswer.ToUpper();
                        if (answer == "Y")
                        {
                            checkPurchase = true;
                            verifyItem = false;
                        }//end of if
                        else if (answer == "N")
                        {
                            checkPurchase = true;
                            verifyPurchase = true;
                        }
                        else
                        {
                            WriteLine("{0} is an invalid answer. Please enter again.. ", inputAnswer);
                            checkPurchase = false;
                        }
                    }//end of loop checkPurchase

                }//end of loop verify Purchase

                WriteLine();
                if (totalPrice >= TOTALDISCOUNT1 && totalPrice <= TOTALDISCOUNT2)
                {
                    discount = DISCOUNT1;
                }
                else if (totalPrice > TOTALDISCOUNT2)
                {
                    discount = DISCOUNT2;
                }
                else
                {
                    discount = 0;
                }

                discountAmount = (totalPrice * discount) / 100;
                //check discount amount

                FinalPrice = totalPrice - discountAmount;
                for(int i = 0; i < 50; i++)
                {
                    Write("*");
                }

                WriteLine(" ");
                WriteLine("Total Items are: " + totalItems);
                WriteLine("Total Prices are: " + totalPrice.ToString("C"));
                WriteLine("Discount " + discount + "%, which will decrease Total Price by " + discountAmount.ToString("C"));
                WriteLine("Your final bill is " + FinalPrice.ToString("C"));
                //Print the invoice

                for (int i = 0; i < 50; i++)
                {
                    Write("*");
                }

                verifyCustomer = false;
                checkCardNumber = false;
                WriteLine();
                while (verifyCustomer == false)
                {
                    Write("Please enter your four-digit card number: ");
                    inputCardNumber = ReadLine();
                    checkCardNumber = int.TryParse(inputCardNumber, out cardNumber);
                    carNumberLenght = inputCardNumber.Length;
                    if (checkCardNumber != true || carNumberLenght != DIGIT)
                    {
                        WriteLine("Invalid card number");
                        verifyCustomer = false;
                    }
                    else
                    {
                        firstThreeNumber = cardNumber / 10;
                        lastNumber = cardNumber % 10;
                        remainder = firstThreeNumber % 7;
                        if (remainder == lastNumber)
                        {
                            WriteLine("Credit card number {0} is valid, Payment accepted", cardNumber);
                            verifyCustomer = true;
                        }
                        else
                        {
                            WriteLine("Credit card is not valid.");
                        }
                    }
                }//end of verify customer
                WriteLine();
                WriteLine("Your final payment is " + FinalPrice.ToString("C"));
                WriteLine("You have paid " + FinalPrice.ToString("C") + " with " + notOwing.ToString("C") + " owing");
                while (checkCustomerContinue == false || customerContinue != 'c' && customerContinue !='C' && customerContinue != 'Q' && customerContinue != 'q')
                {
                    Write("Press Q to Quit or C to continue: ");
                    inputstring = ReadLine();
                    checkCustomerContinue = char.TryParse(inputstring, out customerContinue);
                    if(customerContinue == 'c' || customerContinue == 'C')
                    {
                        verifyPurchase = false;
                        verifyCustomer = false;
                        totalItems = 0;
                        totalPrice = 0;
                        WriteLine();
                        WriteLine("See you next time!");
                        WriteLine();
                    }
                }
                
                ReadKey();

            }//end of check customer continue

        }//end of method

    }//end of class

}//end of namespace
