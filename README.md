# Netacademia Halado.Net programozas

https://netacademia.hu/Tanfolyam/halado-net-programozas

## Típusok áttekintése
CLR futtatókörnyezet áttekintése: fordítás, futtatás, IL nyelv, unsafe code.
System.Object. Beépített típusok. Casting: is és as operátor mûködése.
Primitív, referencia és értéktípusok. Immutable típus fogalma (string).
Nullable típus és mûködési elve.
Boxing és unboxing. Objektumok hash értéke: mikor használjuk?
Konstansok használata. Dynamic típus részletes ismertetése.
Típusok és típustagok láthatósága. Részleges osztályok, struktúrák és interfészek.
Statikus osztályok. Polimorfizmus: virtuális metódusok mûködési elve.

## Metódusok, metódus paraméterek
Konstruktorok osztályokon és struktúrákon.
Típus konstruktorok.
Operator overloading. Implicit és explicit konverziós operátorok.
Extension metódusok. Részleges metódusok.
GetHashCode és Equals helyes implementálása.
Opcionális és named paraméterek. Paraméterek default értéke. REF és OUT paraméterek.
Változó hosszúságú paraméterlista. Implicit típusú lokális változók (var).

## Property-k, delegáltak és események
Property-k elõnyei. Hogyan implementáljuk õket. Láthatósági viszonyok.
Automatikus property-k. Anonymous típusok. Tuple type.
Paraméteres property-k: indexelõk.
A delegate mûködési mechanizmusa. Anonymous metódusok.
Delegate használata callback metódusok létrehozására.
Delegate chain fogalma és használata.
Saját osztály készítése saját eseménnyel. Az eseményre való feliratkozás.
Eseményhez tartozó kivételosztályok elkészítése. Eseménykezelés során mi történik a színfalak mögött?

## Generikusok, interfészek
Elõre definiált generikus típusok: Set, List, Dictionary, Queue, Stack, Bag stb...
Saját generikus típus és kollekció létrehozása.
Generikus metódusok, interfészek és delegate-ek.
Kovariancia és kontravariancia fogalma. Generikus ellenõrzések és megszorítások.
Interfészek létrehozása és használata. Explicit interface metódus implementáció.
Néhány fontosabb beépített interface: IComparable, IDisposable, IEnumerable, IList, ICollection stb...

#Attribútumok, kivételkezelés
Attribútumok szerepe és használata.
Saját egyedi attribútum létrehozása.
Elkészített attribútum használata.
Checked és unchecked mûveletek.
A kivételkezelés mûködési mechanizmusának részletes áttekintése: 
try, catch, finally.
Saját kivételosztály készítése.
Nemkezelt kivételek. Kivitelek debuggolása.
Kivételkezelés során felmerülõ teljesítményproblémák.

##Memória menedzsment, DLL betöltõdés, reflection, serialization
Garbage Collector mûködési mechanizmusa.  
Destructor fogalma. Finalize metódus. Dispose pattern helyes megvalósítása. A using utasítás használata.
Objektumok életciklusának monitorozása és kontrollálása.
Assembly betöltõdés részletes áttekintése. Plugin-ezhetõ alkalmazások készítése: új típusok, metódusok automatikus felismerése.
Teljesítmény megfontolások: reflection mennyire gyors?
Objektumpéldányok bináris és XML alapú sorosítása.

## Aszinkron programozás, többszálú programozás
Thread Pool fogalma. Task-ok programozása. Parallel For, ForEach és Invoke.
Aszinkron metódus végrehajtás. Gyakorlati használat: File és Network mûveletek. Tipikus példa: chat szerver programozása.
IAsyncResult használata. Kivételkezelés aszinkron végrehajtás során.
Egyszerû szálak létrehozása. Prioritások kezelése. Szálak közti kommunikáció.
Szál-szinkronizációs módszerek: volatile, interlocked, spin lock.
Kernel módú módszerek: event, semaphore, mutex.
AutoResetEvent és ManualResetEvent használata.