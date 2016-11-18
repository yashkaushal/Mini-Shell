using System;
using System.IO;

namespace Shell
{
	namespace cat
	{
		class Program
		{
			public static void read(string[] args)
			{
				if (args.Length != 1)
				{
					Console.WriteLine("The syntax of the command is incorrect.");
				}
				else
				{
					if (File.Exists(args[0]) == false)
					{
						Console.WriteLine("File not found");
					}
					else
					{
						string contents = File.ReadAllText(args[0]);
						Console.Write(contents);
					}
				}
			}
		}
	}

	class MainClass
	{

		public static void Main (string[] args)
		{
			string[] history = new string[50];
			int his=0;
			bool start= true;

			string str;
			do {
				Console.Write ("console >");
				str = Console.ReadLine ();

				string[] words = str.Split (' ');

				history[his] = words[0];
				his++;

				switch (words [0]) {
				case "ls":
					if (words.Length != 1)
					{
						Console.WriteLine("The syntax of the command is incorrect.");
						Console.WriteLine(words.Length);
					}
					else{
					{
						DirectoryInfo dir = new DirectoryInfo (Directory.GetCurrentDirectory ());

						foreach (DirectoryInfo d in dir.GetDirectories()) {
							Console.WriteLine ("{0}\t directory", d.Name);
						}

						foreach (FileInfo f in dir.GetFiles()) {
							Console.WriteLine ("{0}\t File", f.Name);
						}
					}
					}
					break;

				case "pwd":
					if (words.Length != 1)
					{
						Console.WriteLine("The syntax of the command is incorrect.");
						Console.WriteLine(words.Length);
					}
					else{
					{
						Console.WriteLine (Directory.GetCurrentDirectory ());
					}
					}
					break;

				case "echo":
					{
						string first_word = words [0];
						foreach (string d in words) {
							if (d.Equals (first_word)) {
							} else {
								Console.Write (d + " ");
							}
						}
						Console.WriteLine ("");

					}
					break;

				case "cat":
					{
						if (words.Length != 2)
						{
							Console.WriteLine("The syntax of the command is incorrect.");
							Console.WriteLine(words.Length);
						}
						else{

						if (File.Exists (words [1]) == false) {
							Console.WriteLine ("File not found");
						} else {
							string contents = File.ReadAllText (words [1]);
							Console.Write (contents);
								Console.WriteLine("");
						}
						}

					}
					break;

				case "exit":
					{
						if (words.Length != 1)
						{
							Console.WriteLine("The syntax of the command is incorrect.");
							Console.WriteLine(words.Length);
						}
						else{
						start = false;
						}
					}
					break;

				case "clear":
					{if (words.Length != 1)
						{
							Console.WriteLine("The syntax of the command is incorrect.");
							Console.WriteLine(words.Length);
						}
					else{
						for( int i = 0 ; i< 100; i++)
						{
							Console.WriteLine("");
						}
					}
					}
					break;

				case "cp":
					{if (words.Length != 3)
						{
							Console.WriteLine("The syntax of the command is incorrect.");
							Console.WriteLine(words.Length);
						}
					else
					{
						if (File.Exists(words[1]) == false)
						{
							Console.WriteLine("Source file not found");
						}
				/*		else if (Directory.Exists(words[2]) == false)
						{
							Console.WriteLine("Target Directory not found");
						}		*/
						else
						{
							File.Copy(words[1], words[2]);

							//some syntax unclear
						}
					}
				}
					break;

				case "history":
					{
						if (words.Length != 1)
						{
							Console.WriteLine("The syntax of the command is incorrect.");
							Console.WriteLine(words.Length);
						}
						else{
						foreach(string s in history)
						{
							if(s != null){
							Console.WriteLine(s);
							}
						}
						}

					}
					break;

					case "cd":
					{
						if (words.Length != 2)
							{
								Console.WriteLine("The syntax of the command is incorrect.");
								Console.WriteLine(words.Length);
							}
						else{
						Environment.CurrentDirectory = words[1];
						}
					}
					break;

				case "grep":
					{if (words.Length != 3)
						{
							Console.WriteLine("The syntax of the command is incorrect.");
							Console.WriteLine(words.Length);
						}
					else
					{
						if (File.Exists(words[2]) == false)
						{
							Console.WriteLine("File not found");
						}
						else
						{
							string[] lines = File.ReadAllLines(words[2]);

							foreach (string line in lines)
							{                        
								if(line.Contains(words[1]))
								{
									Console.WriteLine(line);
								}
							}
						}
					}
				}
					break;

					default:
					{
						Console.WriteLine("no such command");
					}
					break;

				}

			} while(start);
}
}
}