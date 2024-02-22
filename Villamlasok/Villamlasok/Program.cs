using Villamlasok;

var napok = new List<Nap>();
using var sr = new StreamReader(@"..\..\..\src\villam.txt");
try
{
	while (!sr.EndOfStream)
	{
		napok.Add(new Nap(sr.ReadLine()));
	}
}
catch
{
    Console.WriteLine($"Hiba a fájl beolvasása során!");
}
foreach (var nap in napok)
{
    Console.WriteLine(nap);
}

Console.WriteLine("\n3.feladat: ");
LegtobbVillamlas(napok);

Console.WriteLine("\n4.feladat: ");
MikorVoltVillamlas(napok);

Console.WriteLine("\n5.feladat: ");
var villamlott = HanyOlyanOraAholVillamlott(napok);
Console.WriteLine($"Ennyi napon villámlott: {villamlott}");

Console.WriteLine("\n6.feladat: ");
KetszaznalKevesebb(napok);

Console.WriteLine("\n7.feladat: ");
NemVoltVillamlas(napok);

Console.WriteLine("\n8.feladat: ");
HajnaliVillamlas(napok);

Console.WriteLine("\n9.feladat: ");
VillamlasokSzama(napok);

Console.WriteLine("\n10.feladat: ");


Console.WriteLine("\n11.feladat: ");
LegtobbVillamlas7en(napok);

static void LegtobbVillamlas(List<Nap> napok)
{
	var legnagyobbnap = 0;
	var legnagyobbora = 0;
	var legtobbora = 0;
	for (int i = 0; i < napok.Count; i++)
	{
		for (int j = 0; j < napok[i].Orak.Count; j++)
		{
			if (napok[i].Orak[j] > legtobbora)
			{
				legnagyobbora = j + 1;
				legnagyobbnap = i + 1;
				legtobbora = napok[i].Orak[j];
            }
		}
	}
    Console.WriteLine($"A legtöbb villámlás augusztus {legnagyobbnap}. {legnagyobbora}kor volt");
}

static void MikorVoltVillamlas(List<Nap> napok)
{
	using var sw = new StreamWriter(@"..\..\..\src\kiiras.txt");
	for (int i = 0; i < napok.Count; i++)
	{
		var villamlasok = new List<int>();
		for (int j = 0; j < napok[i].Orak.Count; j++)
		{
			if (napok[i].Orak[j] > 0)
			{
				villamlasok.Add(j + 1);
				break;
			}
		}
		if (villamlasok.Any())
		{
            sw.WriteLine($"{i + 1}. {villamlasok[0]} órában");
        }
		else 
		{
			sw.WriteLine($"{i + 1}. null");
		}
	}
}

static int HanyOlyanOraAholVillamlott(List<Nap> napok)
{
	var villamlasnapok = napok.SelectMany(e => e.Orak).Count(e => e > 0);
	return villamlasnapok;
}

static void KetszaznalKevesebb(List<Nap> napok)
{
	bool volte = false;
	for (int i = 0; i < napok.Count; i++)
	{
		var cucc = 0;
		for (int j = 0; j < napok[i].Orak.Count; j++)
		{
			cucc += napok[i].Orak[j];
		}
		if (cucc < 200)
		{
            Console.WriteLine($"Nap amikor 200nál kevesebbet villámlott: Augusztus {i + 1}.");
			volte = true;
            break;
		}
	}
    if (!volte)
    {
        Console.WriteLine($"Nem volt olyan nap ahol 200 alatt villámlott volna");
    }
}

static void NemVoltVillamlas(List<Nap> napok)
{
    bool volte = false;
    for (int i = 0; i < napok.Count; i++)
    {
		
		var cucc = 0;
        for (int j = 0; j < napok[i].Orak.Count; j++)
        {
            cucc += napok[i].Orak[j];
        }
        if (cucc == 0)
        {
            Console.WriteLine($"Nap amikor nem villámlott: Augusztus {i + 1}.");
			volte = true;
            break;
        }
    }
	if (!volte)
	{
        Console.WriteLine($"Nem volt olyan nap ahol ne villámlott volna");
    }
}

static void HajnaliVillamlas(List<Nap> napok)
{
	int szamlalo = 0;
	for (int i = 0; i < napok.Count; i++)
	{
		int j = 0;
		while (j < 2)
		{
			if (napok[i].Orak[j] > 0)
			{
				szamlalo++;
			}
			j++;
		}
	}
    Console.WriteLine($"{szamlalo} óra volt amikor villámlott hajnal 1 és 2kor");
}

static void VillamlasokSzama(List<Nap> napok)
{
	int villamokszama = 0;
	for (int i = 0; i < 20; i++)
	{
		for (int j = 0; j < napok[i].Orak.Count; j++) 
		{
			villamokszama += napok[i].Orak[j];
		}
	}
    Console.WriteLine($"Összesen ennyi villám volt az első 20 napban: {villamokszama}");
}

static void LegkevesebbVillamloOra(List<Nap> napok)
{
	var j = 0;
	while (j < napok[0].Orak.Count)
	{
        var maxorankent = 0;
		for (int i = 0; i < napok.Count; i++)
		{
			maxorankent += napok[i].Orak[j];
		}
		
        j++;
	}
	
	
}

static void LegtobbVillamlas7en(List<Nap> napok)
{
	var max = 0;
	var index = 0;
	for (int i = 0; i < napok[6].Orak.Count; i++)
	{
		if (napok[6].Orak[i] > max)
		{
			max = napok[6].Orak[i];
			index = i + 1;
		}
	}
	Console.WriteLine($"A legtöbb villámlás {max} volt a {index}-ik órában");

}