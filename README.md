# 2D-Shooter (incomplet)

In mare parte, meniul de start si ecranul de final sunt manageruite de scriptul GameManager, unde s assignate functionalitatile de baza ale jocului.

Background-ul meniului de start este facut in Pixlr. Butoanele & Textul sunt facute de mana, in Unity. Meniul are 4 butoane: Play - porneste jocul, Options - de unde se regleaza volumul melodiei de pe fundal, Leaderboard - de unde se poate vizualizeaza lista de Highscores si Exit game care inchide aplicatia. Dupa ce apesi Play, incepe jocul.

Pe parcursul jocului, se retine scorul jucatorului.

In prima instanta, inamicii se deplaseaza spre jucator, dar, pentru a evita caderea lor de pe platformele pe care se afla, am creat ziduri invizibile pe fiecare platforma, iar cand un inamic se atinge de aceste ziduri isi schimba directia, astfel incat sa nu cada de pe platforma. In momentul in care jucatorul atinge unul dintre zidurile de pe o platforma, inamicii automat se indreapta spre jucator sa-l atace.

Exista spawner doar pentru scheleti, pentru ca am considerat ca soldatii sunt mult mai puternici decat scheletii (din punct de vedere al damage-ului dat asupra jucatorului si ale punctelor de viata pe care le detin) si am considerat mai potrivita o abordare "statica" in generarea acestora.

In finalul jocului, apare un ecran de incheiere, asemanator cu meniul de start (are acelasi background). In cadrul acestui ecran, pot aparea 2 mesaje: "You lost.", in cazul in care viata jucatorului a ajuns la 0, deci a murit, sau "You won!", in cazul in care jucatorul a reusit sa bata boss-ul final. Sub aceste mesaje, daca jucatorul a facut un scor mai mare decat ultimul scor din Leaderboard, jucatorul isi poate salva scorul in lista. Pentru a salva lista de highscore-uri, s-a folosit un fisier JSON. 