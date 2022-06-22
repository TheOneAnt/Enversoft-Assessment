using System;
using Microsoft.VisualBasic.FileIO; //for CSV parser

namespace Exercise2;

/// 
/// Jimmy,Smith,102 Long Lane,29384857 == FirstName,LastName,Address,PhoneNumber
/// 
/// The first should show the frequency of the first and last names ordered by frequency descending and then alphabetically
/// ascending.
/// E.g.
/// Smith, 4
/// Jones, 3
/// Martin, 3
/// Brown, 1
/// 


////The second should show the addresses sorted alphabetically by street name.
////E.g.
////12 Acton St
////31 Clifton Rd
////22 Jones Rd
////So ordered by frequency first(descending) and then alphabetically(ascending).
////For the list of names:
////Matt Brown
////Heinrich Jones
////Johnson Smith
////Tim Johnson
///
////The first list should be:
////Johnson, 2
////Brown, 1
////Heinrich, 1
////Jones, 1
////Matt, 1
////Smith, 1
////Tim, 1





public class Program
{
	public static void Main()
	{
		var path = @"C:\Data.csv";
		var listUnsorted = new List<Person>();  //unsorted list of persons from file



		//////////////
		//Read from CSV file using TextFieldParser and create List of Persons
		//////////////
		using (TextFieldParser csvParser = new TextFieldParser(path))
		{
			csvParser.SetDelimiters(new string[] { "," });
			csvParser.HasFieldsEnclosedInQuotes = false;

			// Skip the row with the column names
			csvParser.ReadLine();
			
			while (!csvParser.EndOfData)
			{
				// Jimmy,Smith,102 Long Lane,29384857 == FirstName,LastName,Address,PhoneNumber
				// Read current line fields, pointer moves to the next line.
				string[] fields = csvParser.ReadFields();
				
				listUnsorted.Add(new Person
				{
					FirstName = fields[0],
					LastName = fields[1],
					Address = fields[2],
					PhoneNumber = fields[3]
				});
			}
		}

		//print list before sorting
		foreach (Person person in listUnsorted)
			Console.WriteLine(string.Join(" ", person.FirstName, person.LastName, person.Address, person.PhoneNumber));

		
		
		//sort and print sorted list
		
		//List<Person> listSorted1 = listUnsorted.GroupBy(x => x).OrderByDescending(x => x.Count()).ThenBy(x => x.Key).SelectMany(x => x).ToList();

		var listSorted1 = listUnsorted.OrderBy(c => c.LastName).ThenBy(c => c.FirstName) as List<Person>; //not sure why we must cast explicitly?

		foreach (Person person in listSorted1)
			Console.WriteLine(string.Join(" ", person.FirstName, person.LastName, person.Address, person.PhoneNumber));

		
		
		///Press Enter to Continue
		Console.ReadLine();


	}


/////////////////
/// Classes
/////////////////


	public class Person
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Address { get; set; }
		public string PhoneNumber { get; set; }
		
	}


}












///////////////////////////////////////////
///Misc Stuff  
//////////////////////////////////////////////

/*
 using (var reader = new StreamReader(@"C:\Data.csv"))
		{

			reader.ReadLine(); //Skip first line of headers

			while (!reader.EndOfStream)
			{
				var line = reader.ReadLine();
				var values = line.Split(',');

                listUnsorted.Add(new Person
				{ 
					FirstName = values[0], 
					LastName = values[1],
					Address = values[2],
					PhoneNumber = values[3]
				});
			}
		}

 */





/*
public class Track
{
    public int TrackID { get; set; }
    public string Name { get; set; }
    public string Artist { get; set; }
    public string Album { get; set; }
    public int PlayCount { get; set; }
    public int SkipCount { get; set; }
}

And to create a track list as a List<Track> you simply do this:

var trackList = new List<Track>();

Adding tracks can be as simple as this:

trackList.add( new Track {
    TrackID = 1234,
    Name = "I'm Gonna Be (500 Miles)",
    Artist = "The Proclaimers",
    Album = "Finest",
    PlayCount = 10,
    SkipCount = 1
});

Accessing tracks can be done with the indexing operator:

Track firstTrack = trackList[0];

*/






/*
var path = @"C:\Person.csv";
using (TextFieldParser csvParser = new TextFieldParser(path))
{
	csvParser.SetDelimiters(new string[] { "," });
	csvParser.HasFieldsEnclosedInQuotes = false;

	// Skip the row with the column names
	csvParser.ReadLine();

	while (!csvParser.EndOfData)
	{
		// Jimmy,Smith,102 Long Lane,29384857 == FirstName,LastName,Address,PhoneNumber
		// Read current line fields, pointer moves to the next line.
		string[] fields = csvParser.ReadFields();
		string FirstName = fields[0];
		string LastName = fields[1];
		string Address = fields[2];
		string PhoneNumber = fields[3];

		Console.WriteLine(string.Join(" ", fields));
	}
}

*/

//////////////////
//SORT And ORDER
//////////////////

/*	
var input = new List<string> { "Cat", "Dog", "Mouse", "Cat", "Bat", "Alpaca", "Bat" };
var result = input.GroupBy(x => x).OrderByDescending(x => x.Count()).ThenBy(x => x.Key).SelectMany(x => x).ToList();
Console.WriteLine(string.Join(" ", result));
*/
