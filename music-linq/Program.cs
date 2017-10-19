using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = JsonToFile<Artist>.ReadJson();
            List<Group> Groups = JsonToFile<Group>.ReadJson();

            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================


            //There is only one artist in this collection from Mount Vernon, what is their name and age?
            IEnumerable<Artist> mountVernon = Artists.Where(artist => artist.Hometown == "Mount Vernon");

            //Who is the youngest artist in our collection of artists?
            int youngest = Artists.Min(artist => artist.Age);
            IEnumerable<Artist> youngGun = Artists.Where(artist => artist.Age == youngest);

            //Display all artists with 'William' somewhere in their real name
            var williams = Artists.Where(artist => artist.RealName.Contains("William"));
            foreach (var artist in williams)
            {
                System.Console.WriteLine($"Name: {artist.RealName}");
            }
            //Display the 3 oldest artist from Atlanta
            IEnumerable<Artist> atlantaArtists = Artists.Where(artist => artist.Hometown == "Atlanta").OrderBy(artist => artist.Age).Take(3);
            foreach (var artist in atlantaArtists)
            {
                System.Console.WriteLine($"{artist.RealName}, {artist.Age}");
            }
            //(Optional) Display the Group Name of all groups that have members that are not from New York City
            List<string> NonNewYork = Artists
            .Join(Groups, 
                artist => artist.GroupId, 
                group => group.Id, 
                (artist, group) => {
                    artist.Group = group; 
                    return artist;
                })
            .Where(artist => (artist.Hometown != "New York City" && artist.Group != null))
            .Select(artist => artist.Group.GroupName)
            .Distinct()
            .ToList();
            System.Console.WriteLine("All groups with members not from NYC:");
            foreach(var group in NonNewYork){
                System.Console.WriteLine(group);
            }

            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
        }
    }
}
