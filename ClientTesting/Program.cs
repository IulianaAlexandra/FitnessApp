using ApiClient;
using FitnessAppWebAPI.Models;
using System;
using System.Collections.Generic;

namespace ClientTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new Client();

            client.Post<MuscleGroups>("/MuscleGroup/add", new MuscleGroups() { GroupName = "Test", IdGroup=9 }).Wait();
        }
    }
}
