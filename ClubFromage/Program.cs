﻿using System;
using System.Data;
using MySql.Data.MySqlClient;

using ModelLayer.Data;
using ModelLayer.Business;
using System.Collections.Generic;

namespace ClubFromage
{
    public class Program
    {
        private static Dbal mydbal;
        private static DaoPays myDaoPays;
        private static Pays myPays;
        private static DaoFromage myDaoFromage;
        private static Fromage myFromage;


        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            mydbal = new Dbal("dbclubfromage");
            myPays = new Pays();
            myDaoPays = new DaoPays(mydbal);
            myPays = myDaoPays.SelectById(75);
            Console.WriteLine(myPays.Name);
            //myDaoPays.Insert(myPays);
            //myDaoPays.InsertFromCSV("/ClubFromage;/com");
            //myFromage = new Fromage(2,"Reblochon",default,myPays,default);
            myDaoFromage = new DaoFromage(mydbal, myDaoPays);
            //myDaoFromage.Insert(myFromage);
            //myDaoFromage.InsertFromCSV("C:\\Users\\Administrator\\source\\repos\\ClubFromage\\coucheModel\\tableauNomDep.csv");
            List<Fromage> myFromages = myDaoFromage.SelectAll();
            foreach (Fromage f in myFromages)
            {
                Console.WriteLine(f.Name);
            }
            List<Pays> listPays = myDaoPays.SelectAll();
            foreach (Pays p in listPays)
            {
                Console.WriteLine(p.Name);
            }
            string fromton = "Angors";
            Fromage myFromage = myDaoFromage.SelectByName(fromton);
            myFromage.Name = "Reblochon";
            myDaoFromage.Update(myFromage);
            Console.WriteLine("L'ID du " + fromton + ": " + myFromage.Id);
        }

    }
}
