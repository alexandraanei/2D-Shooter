# 2D-Shooter - Monster Hunter

Echipa este formata din urmatorii studenti : Anei Alexandra, Grigore Clara, Pandelea Adina si Staniea Alexandru.

## Despre joc:
Am realizat un joc platformer, in stilul jocurilor Arcade de la sfarsitul celui de-al XX –lea secol, singleplayer, bidimensional,  in care jucatorul isi controleaza miscarile avatarului prin cele patru taste de tip sageata, putand de asemenea sari folosind tasta spatiu si atacand folosind tasta X. 

Scopul jucatorului este de a avansa pe platformele jocului, evitand inamicii (care sunt de tipuri diferite) si colectand diverse bonusuri ce ii imbunatatesc sansele de supravietuire. Nivelul se termina cu un inamic special, considerabil mai dificil decat inamicii de baza(un inamic de tip “boss”), avand puteri unice pentru care jucatorul trebuie sa planuiasca in avans si pentru a invata sa anticipeze mutarile.

Jucatorul ia la inceperea nivelului o torta ce ii ofera posibilitatea de a ataca inamicii cu proiectile. Pe parcurs, jucatorul poate colecta noi puteri, precum mici power-up-uri pentru cresterea vietii si un scut ce ofera invincibilitate caracterului pentru 10 secunde.
Odata cu irosirea tuturor punctelor de viata (fiecare inamic provoaca un numar variabil de daune), jucatorul va trebui sa reia nivelul.
Jocul se numeste “Monster Hunter”, deoarece jucatorul va intalni diverse tipuri de monstri pe parcursul nivelelor: soldati, scheleti, fantome, etc. 

## Sprite-uri:
Pana in momentul de fata, toate avatarele, atat pentru inamici cat si pentru protagonist, au fost realizate folosind aplicatia web "Piskel": https://www.piskelapp.com/.

Fiecare sprite este format din mai multe imagini PNG, corespondente layer-urilor din etapa de lucru, surprinzand entitatea respectiva in diferite momente.Astfel, puse impreuna si reluate continuu, aceste imagini PNG realizeaza mini-animatii, dand astfel viata personajelor jocului si formand o atmosfera mai dinamica.

Avatarele sunt formate dintr-un numar redus de pixeli, fiind realizate in stilul jocurilor de pe platformele de gaming vechi. Astfel, avatarele din joc sunt imagini fie de 32x32 pixeli, fie de 64x64, fie de 128x128 pixeli. Inamicii de baza, care apar in numar mare in joc, au avatare simple, cu un numar redus de pixeli si putine trasaturi, pe cand protagonistul, inamicii de tip "boss" sau inamicul final au sprite-uri mai detaliate, de o rezolutie mai buna, pastrand insa stilul retro.

Puteti gasi sprite-urile create de noi in fisierul Documentatie.docx din repository.
    
In mare parte, meniul de start si ecranul de final sunt manageruite de scriptul GameManager, unde s assignate functionalitatile de baza ale jocului.

Background-ul meniului de start este facut in Pixlr. Butoanele & Textul sunt facute de mana, in Unity. Meniul are 4 butoane: Play - porneste jocul, Options - de unde se regleaza volumul melodiei de pe fundal, Leaderboard - de unde se poate vizualizeaza lista de Highscores si Exit game care inchide aplicatia. Dupa ce apesi Play, incepe jocul.

Pe parcursul jocului, se retine scorul jucatorului.

In prima instanta, inamicii se deplaseaza spre jucator, dar, pentru a evita caderea lor de pe platformele pe care se afla (in partea de jos am implementat un deathfloor, in cazul in care inamicii/playerul cad, acestia mor), am creat ziduri invizibile pe fiecare platforma, iar cand un inamic se atinge de aceste ziduri isi schimba directia, astfel incat sa nu cada de pe platforma. In momentul in care jucatorul atinge unul dintre zidurile de pe o platforma, inamicii automat se indreapta spre jucator sa-l atace.

Exista spawner doar pentru scheleti, pentru ca am considerat ca soldatii sunt mult mai puternici decat scheletii (din punct de vedere al damage-ului dat asupra jucatorului si ale punctelor de viata pe care le detin) si am considerat mai potrivita o abordare "statica" in generarea acestora.

## Player:
Jocul are ca protagonist un baiat ce se lupta cu monstrii. Acesta poate sa sara si sa se deplaseze pe  platforma.

https://www.gameart2d.com/free-graveyard-platformer-tileset.html

De asemenea, player-ul ataca inamicii cu flacari. La fiecare frame se verifica daca acesta doreste sa traga. Poate sa foloseasca proiectilele doar daca a colectat arma la inceput jocului.

Player-ul are un health bar configurat ce se modifica si cu ajutorul powerup-urilor.

Dupa moartea unor inamici sunt generate random powerup-urile. Cele dedicate cumularii de viata sunt generate cu o probabilitate de 25%, iar cele pentru invincibilitate cu o probabilitate de 12,5%.

Powerup-ul de invinciblitate ajuta player-ul sa nu primeasca damage atunci cand este atacat de orice inamic.

https://www.freepnglogos.com/images/heart-8091.html

http://uploads.twitchalerts.com/000/082/702/462/shield.png

## Inamici:
Player-ul are mai multi adversari , care difera prin viata si damage dat si scor adaugat:
- schelet (viata: 30, damage :10, scor: 20)
- soldat (viata: 40, damage: 20, scor :60)
- fantoma (damage: 30, nu poate fi omorat)
- calugar (damage: 45, nu poate fi omorat)
- boss (prin taur - damage: 30 si prin lance - damage: 20)

## BossFight:
Pentru a putea finaliza jocul caracterul trebuie sa se lupte cu monstrul final, un vampir. Lupta incepe la declansarea trigger-ului de pe ultima platforma, reprezentat de o sageata.

Vampirul are in subordinea lui un taur, pe care il trimite sa atace player-ul. Strategia de atac a player-ului este urmatoarea: sare pe cutia din scena de lupta, atacand vampirul cu proiectile, dar in acelasi timp ferindu-se de lanci proiectate din cer si de tauri.
Scena de lupta are efecte speciale, ceata ce isi schima intensitatea si muzica de fundal specifica, in restul jocului este o alta melodie. De asemenea, cadrul ramane blocat pe scena de lupta.

In cadrul luptei finale spawner-ul de scheleti este oprit, dar inca se mai spawneaza fantoma si calugarul.

In finalul jocului, apare un ecran de incheiere, asemanator cu meniul de start (are acelasi background). In cadrul acestui ecran, pot aparea 2 mesaje: "You lost.", in cazul in care viata jucatorului a ajuns la 0, deci a murit, sau "You won!", in cazul in care jucatorul a reusit sa bata boss-ul final. Sub aceste mesaje, daca jucatorul a facut un scor mai mare decat ultimul scor din Leaderboard, jucatorul isi poate salva scorul in lista. Pentru a salva lista de highscore-uri, s-a folosit un fisier JSON.

## Impartirea de task-uri:
Comunicarea a fost realizata prin WhatsApp si Zoom, iar proiectul a fost creat prin push-urile fiecaruia pe Github. 

Task-urile fiecaruia sunt prezente pe git, dar cum v-am spus și la prezentarea pe discord am lucrat împreuna la majoritatea taskurilor, având in vedere nivelul mic de experiența in Unity. O scurta detaliere de taskuri avem mai jos:

ALEXANDRA:
- meniul
- peretii invizibili de pe platforme
- health-bar
- score/high-score
- animatii

ADINA:
- attack ability la player
- desenatul
- boss fight

CLARA:
- desenatul 
- crearea playerului
- inamici
- boss fight
- animatii

ALEX:
- powerups
- deathfloor
- platforme/decoratiuni
- muzica
- damage
