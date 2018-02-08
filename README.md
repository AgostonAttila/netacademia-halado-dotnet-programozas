# Netacademia Halado.Net programozas

https://netacademia.hu/Tanfolyam/halado-net-programozas

## T�pusok �ttekint�se
CLR futtat�k�rnyezet �ttekint�se: ford�t�s, futtat�s, IL nyelv, unsafe code.
System.Object. Be�p�tett t�pusok. Casting: is �s as oper�tor m�k�d�se.
Primit�v, referencia �s �rt�kt�pusok. Immutable t�pus fogalma (string).
Nullable t�pus �s m�k�d�si elve.
Boxing �s unboxing. Objektumok hash �rt�ke: mikor haszn�ljuk?
Konstansok haszn�lata. Dynamic t�pus r�szletes ismertet�se.
T�pusok �s t�pustagok l�that�s�ga. R�szleges oszt�lyok, strukt�r�k �s interf�szek.
Statikus oszt�lyok. Polimorfizmus: virtu�lis met�dusok m�k�d�si elve.

## Met�dusok, met�dus param�terek
Konstruktorok oszt�lyokon �s strukt�r�kon.
T�pus konstruktorok.
Operator overloading. Implicit �s explicit konverzi�s oper�torok.
Extension met�dusok. R�szleges met�dusok.
GetHashCode �s Equals helyes implement�l�sa.
Opcion�lis �s named param�terek. Param�terek default �rt�ke. REF �s OUT param�terek.
V�ltoz� hossz�s�g� param�terlista. Implicit t�pus� lok�lis v�ltoz�k (var).

## Property-k, deleg�ltak �s esem�nyek
Property-k el�nyei. Hogyan implement�ljuk �ket. L�that�s�gi viszonyok.
Automatikus property-k. Anonymous t�pusok. Tuple type.
Param�teres property-k: indexel�k.
A delegate m�k�d�si mechanizmusa. Anonymous met�dusok.
Delegate haszn�lata callback met�dusok l�trehoz�s�ra.
Delegate chain fogalma �s haszn�lata.
Saj�t oszt�ly k�sz�t�se saj�t esem�nnyel. Az esem�nyre val� feliratkoz�s.
Esem�nyhez tartoz� kiv�teloszt�lyok elk�sz�t�se. Esem�nykezel�s sor�n mi t�rt�nik a sz�nfalak m�g�tt?

## Generikusok, interf�szek
El�re defini�lt generikus t�pusok: Set, List, Dictionary, Queue, Stack, Bag stb...
Saj�t generikus t�pus �s kollekci� l�trehoz�sa.
Generikus met�dusok, interf�szek �s delegate-ek.
Kovariancia �s kontravariancia fogalma. Generikus ellen�rz�sek �s megszor�t�sok.
Interf�szek l�trehoz�sa �s haszn�lata. Explicit interface met�dus implement�ci�.
N�h�ny fontosabb be�p�tett interface: IComparable, IDisposable, IEnumerable, IList, ICollection stb...

#Attrib�tumok, kiv�telkezel�s
Attrib�tumok szerepe �s haszn�lata.
Saj�t egyedi attrib�tum l�trehoz�sa.
Elk�sz�tett attrib�tum haszn�lata.
Checked �s unchecked m�veletek.
A kiv�telkezel�s m�k�d�si mechanizmus�nak r�szletes �ttekint�se: 
try, catch, finally.
Saj�t kiv�teloszt�ly k�sz�t�se.
Nemkezelt kiv�telek. Kivitelek debuggol�sa.
Kiv�telkezel�s sor�n felmer�l� teljes�tm�nyprobl�m�k.

##Mem�ria menedzsment, DLL bet�lt�d�s, reflection, serialization
Garbage Collector m�k�d�si mechanizmusa.  
Destructor fogalma. Finalize met�dus. Dispose pattern helyes megval�s�t�sa. A using utas�t�s haszn�lata.
Objektumok �letciklus�nak monitoroz�sa �s kontroll�l�sa.
Assembly bet�lt�d�s r�szletes �ttekint�se. Plugin-ezhet� alkalmaz�sok k�sz�t�se: �j t�pusok, met�dusok automatikus felismer�se.
Teljes�tm�ny megfontol�sok: reflection mennyire gyors?
Objektump�ld�nyok bin�ris �s XML alap� soros�t�sa.

## Aszinkron programoz�s, t�bbsz�l� programoz�s
Thread Pool fogalma. Task-ok programoz�sa. Parallel For, ForEach �s Invoke.
Aszinkron met�dus v�grehajt�s. Gyakorlati haszn�lat: File �s Network m�veletek. Tipikus p�lda: chat szerver programoz�sa.
IAsyncResult haszn�lata. Kiv�telkezel�s aszinkron v�grehajt�s sor�n.
Egyszer� sz�lak l�trehoz�sa. Priorit�sok kezel�se. Sz�lak k�zti kommunik�ci�.
Sz�l-szinkroniz�ci�s m�dszerek: volatile, interlocked, spin lock.
Kernel m�d� m�dszerek: event, semaphore, mutex.
AutoResetEvent �s ManualResetEvent haszn�lata.