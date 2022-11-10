# Termelő-fogyasztó probléma - extra feladat

Készíts olyan konzolalkalmazást, mely a termelő-fogyasztó problémát implementálja a következőképpen.

A program az indulásakor 3 db. termelő példányt indít, akik folyamatosan termelnek. 

 1. Egy termelő ezt csinálja:
   - Kisorsol egy 1 és 10 közötti véletlen számot, ennyi másodperc alatt készül el egy termék.
   - A termék elkészültéig eltelt másodpercek számát folyamatosan frissíti a konzolon. Az 1. termelő a konzol 1. sorában, a 2. a 2-ikban, a 3. a 3-ikban.
   - Amint elkészül egy termék, azt egy közös várakozási sorba kell helyezni. A konzol 4. sorában frissítse a várakozási sorban található termékek számát! (Ha nem feltétlenül szükséges queue használata, akkor ne használj!)
   - Utána egy következő termék termelésébe fog.
 2. A programban kezdetben legyen 5 db. fogyasztó.
   - A konzol 5. sorában legyen mindig látható a várakozó fogyasztók aktuális száma.
   - A felhasználó akármikor létre tud hozni egy új fogyasztót a 6. sortól lefelé látható egy menü segítségével:
     - A következő billentyűket használhatod:
       - F - Fogyasztó hozzáadása
       - Esc - Vége
   - Amint egy fogyasztó hozzájut egy termékhez (a várakozási sorból), a termék törlődik és a fogyasztó megszűnik létezni.
   - A program figyelje, hogy elfogynak-e a fogyasztók. Ha igen, akkor dobjon kivételt, amit a főprogramnak el kell kapni és megkérdeznie a usert, hogy ki akar-e lépni a programból.

 3. Extraként:
   - Használj színeket! Pl. a visszaszámolásnál egyre élénkebb pirossal írd ki a csökkenő számokat!
   - Találj ki valami kontextust, azaz hogy minek a termelését is szimulálod, és ennek megfelelően pimpeld fel a user interfészt!

<br><br>
megjegyzés: feladatokból egyedül a kontextus kitalálását nem csináltam meg
