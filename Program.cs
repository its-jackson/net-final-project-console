using System;
using System.Data.SqlClient;
using System.Text;

namespace library_system
{
    class Program
    {
        // azure sql database connection string
        static string azure = "Server=tcp:semester2.database.windows.net,1433;Database=net;User ID=jackson200337556;Password=Johnson9;Trusted_Connection=False;Encrypt=True;";
        static void Main(string[] args)
        {
            // Table - Library
            // DisplayBooks();      COMPLETE       
            // InsertBook();        COMPLETE    
            // UpdateBook();        COMPLETE    
            // DeleteBook();        COMPLETE

            // Table - Library_Members
            // DisplayMembers();    COMPLETE            
            // InsertMember();      COMPLETE    
            // UpdateMember();      COMPLETE    
            // DeleteMember();      COMPLETE    

            // Table - Library_Book_Rentals
            // DisplayRentals();    COMPLETE 
            // InsertRental();      COMPLETE     
            // UpdateRental();      COMPLETE     
            // DeleteRental();      COMPLETE 

            Menu();
        }

        public static void Menu()
        {
            Console.WriteLine("1. Library Members");
            Console.WriteLine("2. Book Rentals");
            Console.WriteLine("3. Export Database");
            Console.WriteLine("4. Exit");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("A) Insert Member");
                    Console.WriteLine("B) Display Members");
                    Console.WriteLine("C) Update Member Info");
                    Console.WriteLine("D) Delete Member ");
                    Console.WriteLine("E) Main Menu ");
                    char memberChoice = char.Parse(Console.ReadLine());
                    switch (memberChoice)
                    {
                        case 'A':
                            InsertMember();
                            Menu();
                            break;

                        case 'B':
                            DisplayMembers();
                            Menu();
                            break;

                        case 'C':
                           UpdateMember();
                            Menu();
                            break;

                        case 'D':
                            DeleteMember();
                            Menu();
                            break;

                        case 'E':
                            Menu();
                            break;
                    }
                    break;


                case 2:
                    Console.WriteLine("A) Rent A Book");
                    Console.WriteLine("B) Display Book Rentals");
                    Console.WriteLine("C) Update Book Rental");
                    Console.WriteLine("D) Delete Book Rental");
                    Console.WriteLine("E) Main Menu ");
                    char rentalChoice = char.Parse(Console.ReadLine());
                    switch (rentalChoice)
                    {
                        case 'A':
                            InsertRental();
                            Menu();
                            break;

                        case 'B':
                            DisplayRentals();
                            Menu();
                            break;

                        case 'C':
                            UpdateRental();
                            Menu();
                            break;

                        case 'D':
                            DeleteRental();
                            Menu();
                            break;

                        case 'E':
                            Menu();
                            break;
                    }
                    break;

                case 3:
                    Console.WriteLine("Function Coming Soon");
                    Menu();
                    break;

                case 4:
                    Console.WriteLine("Exit");
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid argument");
                    Menu();
                    break;
            }
        }

        public static void InsertRental()
        {
            try
            {
                Console.WriteLine("Enter Member ID: \n");
                string memberID = Console.ReadLine();

                Console.WriteLine("\nEnter Book Name: \n");
                string bookName = Console.ReadLine();

                Console.WriteLine("\nEnter Book Author: \n");
                string bookAuthor = Console.ReadLine();

                Console.WriteLine("\nEnter Book Genre: \n");
                string bookGenre = Console.ReadLine();

                Console.WriteLine("\nEnter Start Date (YYYY/MM/DD) : \n");
                string startDate = Console.ReadLine();

                Console.WriteLine("\nEnter Return Date (YYYY/MM/DD) : \n");
                string returnDate = Console.ReadLine();

                using (SqlConnection connection = new SqlConnection(azure))
                {
                    connection.Open();
                    StringBuilder sb = new StringBuilder();
                    sb.Append("INSERT INTO library_book_rentals (member_id, book_name, book_author, book_genre, start_date, return_date) VALUES (@memberID, @bookName, @bookAuthor, @bookGenre, @startDate, @returnDate)");
                    string sql = sb.ToString();

                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@memberID", memberID);
                    command.Parameters.AddWithValue("@bookName", bookName);
                    command.Parameters.AddWithValue("@bookAuthor", bookAuthor);
                    command.Parameters.AddWithValue("@bookGenre", bookGenre);
                    command.Parameters.AddWithValue("@startDate", startDate);
                    command.Parameters.AddWithValue("@returnDate", returnDate);
                    command.ExecuteNonQuery();
                    connection.Close();
                    Console.WriteLine("\nRental Added!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
            Console.WriteLine("\nDone. Press enter.");
            Console.ReadLine();
        }
        
        public static void UpdateRental()
        {
            try
            {
                Console.WriteLine("Enter Member ID: \n");
                string memberID = Console.ReadLine();

                Console.WriteLine("\nEnter New Book Name: \n");
                string newName = Console.ReadLine();

                Console.WriteLine("\nEnter New Author: \n");
                string newAuthor = Console.ReadLine();

                Console.WriteLine("\nEnter New Book Genre: \n");
                string newGenre = Console.ReadLine();

                Console.WriteLine("\nEnter New Start Date (YYYY/MM/DD) : \n");
                string newStartDate = Console.ReadLine();

                Console.WriteLine("\nEnter New Return Date (YYYY/MM/DD) : \n");
                string newReturnDate = Console.ReadLine();

                using (SqlConnection connection = new SqlConnection(azure))
                {
                    connection.Open();
                    StringBuilder sb = new StringBuilder();
                    sb.Append("UPDATE library_book_rentals SET book_name = @newName, book_author = @newAuthor, book_genre = @newGenre, start_date = @newStartDate, return_date = @newReturnDate WHERE member_id = @memberID;");
                    string sql = sb.ToString();

                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@newName", newName);
                    command.Parameters.AddWithValue("@newAuthor", newAuthor);
                    command.Parameters.AddWithValue("@newGenre", newGenre);
                    command.Parameters.AddWithValue("@newStartDate", newStartDate);
                    command.Parameters.AddWithValue("@newReturnDate", newReturnDate);
                    command.ExecuteNonQuery();
                    connection.Close();
                    Console.WriteLine("\nRental Updated!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
            Console.WriteLine("\nDone. Press enter.");
            Console.ReadLine();
        }

        public static void DeleteRental()
        {
            try
            {
                Console.WriteLine("Enter Member ID To DELETE: \n");
                string memberID = Console.ReadLine();

                using (SqlConnection connection = new SqlConnection(azure))
                {
                    connection.Open();
                    StringBuilder sb = new StringBuilder();
                    sb.Append("DELETE FROM library_book_rentals WHERE member_id = @memberID;");
                    string sql = sb.ToString();

                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@memberID", memberID);
                    command.ExecuteNonQuery();
                    connection.Close();
                    Console.WriteLine("\nRental Deleted!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
            Console.WriteLine("\nDone. Press enter.");
            Console.ReadLine();
        }

        public static void DisplayRentals()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(azure))
                {
                    Console.WriteLine("\nDisplay All Rentals:");
                    Console.WriteLine("=========================================\n");

                    connection.Open();
                    StringBuilder sb = new StringBuilder();
                    sb.Append("SELECT book_name, book_author, book_genre, start_date, return_date ");
                    sb.Append("FROM library_book_rentals;");
                    String sql = sb.ToString();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            Console.WriteLine("Book Name | Book Author | Book Genre | Start Date | Return Date\n");
                            while (reader.Read())
                            {
                                Console.WriteLine("{0} | {1} | {2} | {3} | {4}", reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetDateTime(3), reader.GetDateTime(4));
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine("\nDone. Press enter.");
            Console.ReadLine();
        }

        public static void InsertMember()
        {
            try
            {
                Console.WriteLine("Enter First Name: \n");
                string fName = Console.ReadLine();

                Console.WriteLine("\nEnter Last Name: \n");
                string lName = Console.ReadLine();

                Console.WriteLine("\nEnter Phone Number: \n");
                string phone = Console.ReadLine();

                Console.WriteLine("\nEnter Email Address: \n");
                string email = Console.ReadLine();

                Console.WriteLine("\nEnter Home Address: \n");
                string location = Console.ReadLine();

                using (SqlConnection connection = new SqlConnection(azure))
                {
                    connection.Open();
                    StringBuilder sb = new StringBuilder();
                    sb.Append("INSERT INTO library_members (first_name, last_name, phone_number, email, home_address) VALUES (@fname, @lname, @phone, @email, @location)");
                    string sql = sb.ToString();

                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@fname", fName);
                    command.Parameters.AddWithValue("@lname", lName);
                    command.Parameters.AddWithValue("@phone", phone);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@location", location);
                    command.ExecuteNonQuery();
                    connection.Close();
                    Console.WriteLine("\nMember Inserted!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
            Console.WriteLine("\nDone. Press enter.");
            Console.ReadLine();
        }

        public static void UpdateMember()
        {
            try
            {
                Console.WriteLine("Enter Member Email Address: \n");
                string email = Console.ReadLine();

                Console.WriteLine("\nEnter New First Name: \n");
                string newFName = Console.ReadLine();

                Console.WriteLine("\nEnter New Last Name: \n");
                string newLName = Console.ReadLine();

                Console.WriteLine("\nEnter New Phone Number: \n");
                string newPhone = Console.ReadLine();

                Console.WriteLine("\nEnter New Email Address: \n");
                string newEmail = Console.ReadLine();

                Console.WriteLine("\nEnter New Location: \n");
                string newLocation = Console.ReadLine();

                using (SqlConnection connection = new SqlConnection(azure))
                {
                    connection.Open();
                    StringBuilder sb = new StringBuilder();
                    sb.Append("UPDATE library_members SET first_name = @newFName, last_name = @newLName, phone_number = @newPhone, email = @newEmail, location = @newLocation WHERE email = @email;");
                    string sql = sb.ToString();

                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@newFName", newFName);
                    command.Parameters.AddWithValue("@newLName", newLName);
                    command.Parameters.AddWithValue("@newPhone", newPhone);
                    command.Parameters.AddWithValue("@newEmail", newEmail);
                    command.Parameters.AddWithValue("@newLocation", newLocation);
                    command.ExecuteNonQuery();
                    connection.Close();
                    Console.WriteLine("\nBook Updated!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
            Console.WriteLine("\nDone. Press enter.");
            Console.ReadLine();
        }

        public static void DeleteMember()
        {
            try
            {
                Console.WriteLine("Enter Email To DELETE: \n");
                string email = Console.ReadLine();

                using (SqlConnection connection = new SqlConnection(azure))
                {
                    connection.Open();
                    StringBuilder sb = new StringBuilder();
                    sb.Append("DELETE FROM library_members WHERE email = @email;");
                    string sql = sb.ToString();

                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@email", email);
                    command.ExecuteNonQuery();
                    connection.Close();
                    Console.WriteLine("\nMember Deleted!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
            Console.WriteLine("\nDone. Press enter.");
            Console.ReadLine();
        }

        public static void DisplayMembers()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(azure))
                {
                    Console.WriteLine("\nDisplay All Members:");
                    Console.WriteLine("=========================================\n");

                    connection.Open();
                    StringBuilder sb = new StringBuilder();
                    sb.Append("SELECT first_name, last_name, phone_number, email, home_address ");
                    sb.Append("FROM library_members;");
                    String sql = sb.ToString();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            Console.WriteLine("First Name | Last Name | Phone | Email | Location\n");
                            while (reader.Read())
                            {
                                Console.WriteLine("{0} | {1} | {2} | {3} | {4}", reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4));
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine("\nDone. Press enter.");
            Console.ReadLine();
        }

        public static void InsertBook()
        {
            try
            {
                // SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                // builder.ConnectionString = "Server=tcp:semester2.database.windows.net,1433;Database=net;User ID=jackson200337556;Password=Johnson9;Trusted_Connection=False;Encrypt=True;";

                Console.WriteLine("Enter Book Name: \n");
                string name = Console.ReadLine();

                Console.WriteLine("\nEnter Book Author: \n");
                string author = Console.ReadLine();

                Console.WriteLine("\nEnter Book Genre: \n");
                string genre = Console.ReadLine();

                using (SqlConnection connection = new SqlConnection(azure))
                {
                    connection.Open();
                    StringBuilder sb = new StringBuilder();
                    sb.Append("INSERT INTO library (book_name, book_author, book_genre) VALUES (@name, @author, @genre)");
                    string sql = sb.ToString();

                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@author", author);
                    command.Parameters.AddWithValue("@genre", genre);
                    command.ExecuteNonQuery();
                    connection.Close();
                    Console.WriteLine("\nBook Inserted!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
            Console.WriteLine("\nDone. Press enter.");
            Console.ReadLine();
        }

        public static void UpdateBook()
        {
            try
            {
                Console.WriteLine("Enter Book Name To UPDATE: \n");
                string name = Console.ReadLine();

                Console.WriteLine("\nEnter New Book Name: \n");
                string newName = Console.ReadLine();

                Console.WriteLine("\nEnter New Book Author: \n");
                string author = Console.ReadLine();

                Console.WriteLine("\nEnter New Book Genre: \n");
                string genre = Console.ReadLine();

                using (SqlConnection connection = new SqlConnection(azure))
                {
                    connection.Open();
                    StringBuilder sb = new StringBuilder();
                    sb.Append("UPDATE library SET book_name = @newName, book_author = @author, book_genre = @genre WHERE book_name = @name;");
                    string sql = sb.ToString();

                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@newName", newName);
                    command.Parameters.AddWithValue("@author", author);
                    command.Parameters.AddWithValue("@genre", genre);
                    command.Parameters.AddWithValue("@name", name);
                    command.ExecuteNonQuery();
                    connection.Close();
                    Console.WriteLine("\nBook Updated!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
            Console.WriteLine("\nDone. Press enter.");
            Console.ReadLine();
        }

        public static void DeleteBook()
        {
            try
            {
                Console.WriteLine("Enter Book Name To DELETE: \n");
                string name = Console.ReadLine();

                using (SqlConnection connection = new SqlConnection(azure))
                {
                    connection.Open();
                    StringBuilder sb = new StringBuilder();
                    sb.Append("DELETE FROM library WHERE book_name = @name;");
                    string sql = sb.ToString();

                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@name", name);
                    command.ExecuteNonQuery();
                    connection.Close();
                    Console.WriteLine("\nBook Deleted!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
            Console.WriteLine("\nDone. Press enter.");
            Console.ReadLine();
        }

        public static void DisplayBooks()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(azure))
                {
                    Console.WriteLine("\nDisplay All Books:");
                    Console.WriteLine("=========================================\n");

                    connection.Open();
                    StringBuilder sb = new StringBuilder();
                    sb.Append("SELECT book_name, book_author, book_genre ");
                    sb.Append("FROM library;");
                    String sql = sb.ToString();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            Console.WriteLine("Book Name | Book Author | Book Genre\n");
                            while (reader.Read())
                            {
                                Console.WriteLine("{0} | {1} | {2}", reader.GetString(0), reader.GetString(1), reader.GetString(2));
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine("\nDone. Press enter.");
            Console.ReadLine();
        }
    }
}
