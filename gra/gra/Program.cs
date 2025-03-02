using System.Security.Cryptography.X509Certificates;

int bohater = 30, x;
Random kosc = new Random();

List<Potwor> potwory = new List<Potwor>{
    new Potwor("Nieumarly", 15, 7),
    new Potwor("Goblin", 20, 13),
    new Potwor("Smok", 50, 20),
    new Potwor("Szczur", 4, 1),
    new Potwor("Karzel", 10, 4),
    new Potwor("Bezdomny czarodziej posiadający HIV", 25, 10),
    new Potwor("Lebron James", 70, 25)
};

List<Bron> bronie = new List<Bron>{
    new Bron("Ciasto", 15),
    new Bron("Miecz", 10),
    new Bron("Krasnal ogrodowy", 100000),
    new Bron("Dysk HDD (rzucalny)", 12),
    new Bron("Wrzątek", 20),
    new Bron("Złamana linijka", 7),
};

//wypisywanie dostepnych broni
Console.WriteLine("Wybierz broń (wpisz odpowiadającą liczbę)");
for (int i = 0; i < bronie.Count; i++) {
    Console.WriteLine($"{i} - {bronie[i].Nazwa}");
}

//wybieranie broni
do {
    x = Convert.ToInt16(Console.ReadLine());
}
while (x < 0 || x > bronie.Count - 1);

Console.WriteLine("");
Console.WriteLine($"Wybrałeś {bronie[x].Nazwa}");
Console.WriteLine("");

Potwor przeciwnik = potwory[kosc.Next(potwory.Count)];
Console.WriteLine($"Na Twojej drodze stanął {przeciwnik.Nazwa}");
Console.WriteLine("");
do {
    //maksymalna wartosc obrazen jaka moze otrzymac przeciwnik zalezy od wybranej broni (chyba dziala)
    int rzut = kosc.Next(1, bronie[x].Obr);
    przeciwnik.Zycie -= rzut;
    Console.WriteLine($"{przeciwnik.Nazwa} otrzymał {rzut} obrażeń, i zostało mu {przeciwnik.Zycie} życia");
    if (przeciwnik.Zycie <=0) continue;
    //maksymalna wartosc obrazen jaka moze otrzymac bohater zalezy od przeciwnika(to tez chyba działa)
    rzut = kosc.Next(1, przeciwnik.Obr);
    bohater -= przeciwnik.Obr;
    Console.WriteLine($"Bohater otrzymał {rzut} obrażeń, i zostało mu {bohater} życia");
} while (bohater > 0 && przeciwnik. Zycie > 0);

Console.WriteLine(bohater > przeciwnik.Zycie? "Bohater wygral!": $"{przeciwnik.Nazwa} wygral!");

class Potwor{
    public string Nazwa;
    public int Zycie;
    public int Obr;
    public Potwor(string nazwa, int zycie, int obr)
    {
        Nazwa = nazwa;
        Zycie = zycie;
        Obr = obr;
    }
}
class Bron
{
    public string Nazwa;
    public int Obr;
    public Bron(string nazwa, int obr)
    {
        Nazwa = nazwa;
        Obr = obr;
    }
}
