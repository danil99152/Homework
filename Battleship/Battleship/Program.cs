﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var User = new User();
            var Bot = new Bot();
            HandlerUser handlerUser = new HandlerUser();
            HandlerBot handlerBot = new HandlerBot(); 
            
            User.HitUser += handlerUser.Message;
            User.Miss += handlerUser.OutOfTarget; 
            Bot.HitBot += handlerBot.Message; 

            Boolean yes = true;
            while (yes)
            {
                while (true)
                {
                    User.Output(User.ShipField.field);
                    User.Strike();
                    if (User.Win())
                    {
                        break;
                    }
                    Bot.Strike();
                    if (Bot.Lose())
                    {
                        break;
                    }
                }
                Console.SetCursorPosition(30, 1);
                Console.WriteLine("Хотите сыграть еще раз? ");
                if (Console.ReadLine() != "да")
                {
                    yes = false;
                }
            }
            Console.ReadKey();
        }
    }
}