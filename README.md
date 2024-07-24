# Parking problem

Ova aplikacija rješava problem parkiranja automobila koristeći **Breadth-First Search (BFS) algoritam**. Riječ je o .NET konzolnoj aplikaciji koja pomaže u pronalaženju minimalnog broja koraka potrebnih za prelazak iz početnog stanja u željeno krajnje stanje promjenom rasporeda automobila unutar parking prostora.

## Opis

Aplikacija traži od korisnika da unese početne i završne pozicije automobila u parking prostoru. Svaka pozicija treba biti unesena kao niz brojeva odvojenih razmacima, gdje svaki broj predstavlja automobil, a njegovo mjesto u nizu predstavlja njegovo parking mjesto.

### Format Unosa

- **Početno Stanje**: Unesite početne pozicije automobila odvojene razmacima. Na primjer, '2 0 1 3' označava da je automobil 2 na prvom mjestu, drugo mjesto je prazno, automobil 1 je na trećem mjestu itd.
- **Konačno Stanje**: Unesite željene konačne pozicije automobila, također odvojene razmacima, slijedeći isti format kao početno stanje.

### Izlaz

Program prikazuje minimalan broj koraka potreban za dostizanje konačnog stanja iz početnog stanja. Ako rješenje ne postoji, to će biti ispisano.

Dodatno, za svaki korak ka rješenju, program prikazuje stanje parkinga nakon tog koraka.

## Zahtjevi

- [.NET SDK](https://dotnet.microsoft.com/download) verzija 8.0

## Pokretanje Aplikacije

1. Klonirajte repozitorij na svoj lokalni računar.
2. Idite u direktorij projekta u vašem terminalu.
3. Pokrenite aplikaciju koristeći komandu:

    ```bash
    dotnet run
    ```

4. Slijedite upute na ekranu za unos početnih i konačnih stanja.
