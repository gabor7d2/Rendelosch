# Projekt előkészítési útmutató

Ebben az útmutatóban bemutatom, hogyan készítsd elő a gépeden a RendelőSCH projektet, így nem a workshopon kell ezzel foglalkoznod.

A projekt ASP.NET Core 8.0-s keretrendszert használ, ezért egy C# / .NET-et kezelő fejlesztőkörnyezetet fogunk használni. A **JetBrains Rider**-t vagy a **Visual Studio Code**-ot javaslom.

A Rider teljesebb élményt nyújt, mint a VS Code, ezért elsősorban ezt javaslom, viszont ez egy fizetős szoftver, 30 napos próbaidővel. Egyetemi hallgatók, vagy GitHub Student Developer Pack-kel rendelkező felhasználók igényelhetnek a JetBrains-től tanulói licenszt, amivel ingyen használhatják a JetBrains termékeket 1 éven keresztül (évente meg kell újítani). Azt javaslom, kezdd el a tanulói licensz igénylését, és amíg nem készül el, használd a 30 napos próbaidőt.

Ha valamilyen oknál fogva nem szeretnél tanulói licenszt igényelni, vagy nem szeretnél Rider-t használni, akkor a VS Code-ot javaslom, esetleg Windows-ra Visual Studio-t.

Természetesen nyugodtan használhatsz bármi mást is, viszont útmutatót a Rider-hez és a VS Code-hoz készítettem, ha valami mást szeretnél használni, azt Neked kell előkészítened.


## .NET SDK telepítése
- Töltsd le a .NET SDK 8.0-t [innen](https://dotnet.microsoft.com/en-us/download), majd telepítsd fel

## Rider
### JetBrains tanulói licensz igénylése

[Információk](https://www.jetbrains.com/community/education/#students)

[Itt tudod igényelni](https://www.jetbrains.com/shop/eform/students)

3 mód van az igénylésre, legegyszerűbbtől a legnehezebbig:
- **GitHub Student Developer Pack**: Ha már van GitHub Student Pack-ed, akkor szimplán bejelentkezel a GitHub-odra és már meg is kapod a licenszt.
![](/img/jetbrains_license_github.png)
- **Egyetemi email cím**: A @edu.bme.hu-s email címedet megadva azonosíthatod magad, mint hallgató, ebben az esetben is megkapod azonnal a licenszt. (Kaptam olyan infót, hogy ez lehet, hogy nem működik jelenleg, de egy próbát megér)
![](/img/jetbrains_license_email.png)
- **Hallgatói jogviszony igazolással (Official document)**: Diákigazolványod két oldalát lefotózva, és esetleg egy jogviszony igazolást még mellé csatolva (Neptun 027-es kérvény, vagy KTH-ból személyesen) igényelhető, ez nem azonnali de pár napon belül meg szokott lenni.

A licensz igénylését követően a megadott email címmel fogsz majd tudni belépni a JetBrains felhasználódba.

### Rider telepítése
- Töltsd le a telepítőt [innen](https://www.jetbrains.com/rider/download/), majd telepítsd fel, és jelentkezz be a JetBrains felhasználóddal.

### Projekt letöltése
- Jobb felső sarokban a **Get from VCS** gombot nyomd meg, majd add meg a repó linkjét: `https://github.com/gabor7d2/Rendelosch.git`, és egy tetszőleges helyet ahova menteni szeretnéd (lehetőleg az útvonalon ne legyenek ékezetek és space-k)
- Ezután nyomd meg a **Clone** gombot
![](/img/rider_clone.png)
- Kövesd a Rider utasításait, például ha szól, hogy szeretné telepíteni a .NET SDK-t, mert még nincs a gépeden

### Projekt futtatása
- Ha minden igaz, mostmár el tudod indítani a projektet a jobb felső sarokban található **Run** gombbal.
![](/img/rider_run.png)
- Ezt kell látnod elindítás után:
![](/img/rider_running.png)
- Nyisd meg a weboldalt a linkre kattintva, és nézd meg, betölt-e:
![](/img/weboldal.png)


## VS Code
- Töltsd le VS Code telepítőt [innen](https://code.visualstudio.com/download), majd telepítsd fel.
- Telepítsd fel a "C# Dev Kit" nevű VS Code extension-t
![](/img/vscode_extension.png)

### Projekt letöltése
- Menj vissza VS Code-ban az **Explorer** fülre, nyomd meg a **Clone repository** gombot, majd add meg a repó linkjét: `https://github.com/gabor7d2/Rendelosch.git`
![](/img/vscode_clone.png)
![](/img/vscode_clone_2.png)
- Ezután add meg, hova mentse a projektet
- Kövesd a VS Code utasításait

### Projekt futtatása
- Nyisd meg a Program.cs fájlt, és ha minden igaz, mostmár el tudod indítani a projektet a jobb felső sarokban található **Run** gombbal.
![](/img/vscode_run.png)
- Ezt kell látnod elindítás után:
![](/img/vscode_running.png)
- Nyisd meg a weboldalt a linkre kattintva, és nézd meg, betölt-e:
![](/img/weboldal.png)




