using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyConnection
{
    class Program
    {
        static void Main(string[] args)
        {
            var con = new Connection();
            var q = $@"BEGIN
            declare @likePart varchar(15);
            declare @likePart2 varchar(15);
            declare @row_not_found exception for sqlstate value '02000';
            declare @returnValue varchar(1000);

            declare @myCursor dynamic scroll cursor for
            select ps_attribute_value_id from ps_attribute_value;
            open @myCursor;
                fetch first @myCursor into @likePart;
                while not sqlstate = @row_not_found loop
                set @returnValue = @returnValue + @likePart + ', ';
                fetch next @myCursor into @likePart;
                end loop;         
            close @myCursor;
            select * from inv_redist_allocation;
            select * from branch_employee;
            select quote_no from quote_header;   
            select * from part_master;
            select * from invoice_item;
            select * from invoice_item;
            select * from quote_item;

            if length(@returnValue) > 0 then
            set @returnValue = substring(@returnValue, 1, length(@returnValue) - 2);
            end if;
            select coalesce(@returnValue,'') as partList;
            END";
            var result = new object();
            for (var i = 0; i < 200; i++)
            {
                using (var cmd = con.GetStoredProcCommand("Create48CursorsLog"))
                {
                    try
                    {
                        using (IDataReader reader = con.ExecuteReader(cmd, null))
                        {
                            if (reader.Read())
                            {
                                Console.WriteLine($"{reader[0]}");
                            }
                        }
                        result = con.ExecuteScalar(cmd, null);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                System.Threading.Thread.Sleep(2000);
            }
            
            Console.ReadLine();
        }
    }
}
