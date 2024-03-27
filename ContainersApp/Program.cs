using ContainersApp;

ColdContainer coldContainer = new ColdContainer(30, 10, 20, 100, "Fish");
GasContainer gasContainer = new GasContainer(30, 10, 20, 100, 2);
LiquidContainer liquidContainer = new LiquidContainer(30, 10, 20, 100, true);
Ship ship = new Ship(34,8427423,3495345);
ship.AddContainer(coldContainer);
ship.AddContainer(gasContainer);
ship.AddContainer(liquidContainer);

Console.WriteLine(ship);
List<BaseСontainer> list = new List<BaseСontainer>() { coldContainer, coldContainer, liquidContainer };
ship.AddContainers(list);

Console.WriteLine(ship);