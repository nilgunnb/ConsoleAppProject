using CAProject.Service.Services.Implementations;

MenuService menuservice = new MenuService();

Console.WriteLine("1.As Admin");
Console.WriteLine("2.As User");

string request = Console.ReadLine();

if (request == "1")
{
    bool result = await menuservice.Login();

    while (!result)
    {

        result = await menuservice.Login();

        if (!result)
        {
            Console.WriteLine("2. Return as User");
            request = Console.ReadLine();

            if (request == "2")
            {
                result = true;
            }
        }
    }
}

if (menuservice.IsAdmin)
{
    menuservice.ShowMenuAdmin();
}
else
{
    menuservice.ShowMenuUser();
}
