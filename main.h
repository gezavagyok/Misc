/**
[w][r][b][r][b][w][w][w][r][w][w][b][b][r][r][r][r][w][w][r][b][r][b][w][w][w][r][w][w][b][b][r][r][r][r][w] original

[1][1][ ][1][ ][1][1][1][1][1][1][ ][ ][1][1][1][1][1][1][1][ ][1][ ][1][1][1][1][1][1][ ][ ][1][1][1][1][1] red
-----2   --1   -----------------6       -------------------7   --1    ----------------6      -------------5

[1][ ][1][ ][1][1][1][1][ ][1][1][1][1][ ][ ][ ][ ][1][1][ ][1][ ][1][1][1][1][ ][1][1][1][1][ ][ ][ ][ ][1] blue
--1   --1   ----------4    -----------4            -----2   --1   -----------4   -----------4            --1
**/

/*
ID: csrbgez1
PROG: beads
LANG: C++
*/
#include <iostream>
#include <fstream>
#include <string>



using namespace std;

/**
 * Bead
 * egy 2x-esen lancolt lista elemei, annyit tarolnak, hogy milyen szinu lehet egy gyongy.
 * a hibakereses soran a visszafele maszkalas nem ment, de ezt nem hinnem hogy osztalyhiba.
 */

class Bead{
    bool red;
    bool blue;
    Bead* next;
    Bead* before;
public:
    Bead(char color)
    {
        switch
        (color)
        {
            case 'r': red=true;     blue=false; break;
            case 'b': red=false;    blue=true;  break;
            case 'w': red=true;     blue=true;  break;
        }
    }
    void set_next(Bead* next)       { this->next=next; }
    Bead* get_next()                { return next;}
    bool is_red()                   { return red;}
    bool is_blue()                  { return blue;}
    void set_before(Bead* before)   { this->before=before;}
    Bead* get_before()              { return before;}
};

int
main() {
    ofstream fout ("beads.out");
    ifstream fin ("beads.in");

    int nr; fin >> nr;                  /// nr a gyongyok szama, ha a vegeredmeny ennel tobb, akkor a legtobb begyujtheto gyongy == nr
    char color; fin >> color;
    Bead* first=new Bead(color);        /// elso gyongy kesz

    Bead* neck=first;                   /// futo pointer
    Bead* bef;                          /// futo 2

    for
    (int i=1;i<nr; i++)
    {
        fin >> color;                       ///szin OK
        neck->set_next(new Bead(color));        /// uj gyongy szinnel
        bef=neck;                               /// regi set
        neck=neck->get_next();              /// next OK
        neck->set_before(bef);              /// before OK

    }neck->set_next(first);                 /// utolso utan elso jon
    first->set_before(neck);

    /******************/
    neck=first;     /// kiiratas
    for
    (int i=0; i<nr*2; i++)
    {
        cout << neck->is_red();
        neck=neck->get_next();
    }
    neck=first; cout << endl;

    for
    (int i=0; i<nr*2;i++)
    {
        cout << neck->is_blue();
        neck=neck->get_next();
    }cout << endl;
    /******************/

    int reds=0; int blues=0;    int never_ending=0;

    bool red_first;
    int most=0;

    for
    (int j=0; j<2; j++)     /// egyszer ugy, hogy a kek vonalrol kezdi, egyszer ugy, hogy a piros vonalrol kezdi
    {
        if(j==0) red_first=true;
        if(j==1) red_first=false;
        blues=0; reds=0;

            neck=first;
            for(int i=0; i<nr*2; i++)
            {
                switch(red_first)       /// ez azt akarja eldonteni, hogy piros vagy kek vonalon vagyunk eppen.
                {
                    case true:

                                while(neck->is_red())       /// ha piros vonalon vagyunk, a pirosakat kell eloszor szamolni
                                {
                                    reds++;
                                    neck=neck->get_next();
                                }                           /// amig van, addig megy
                                while(neck->is_blue())
                                {                           /// aztan keket szamol
                                    blues++;
                                    neck=neck->get_next();
   /** itt mar van 2 szin -->*/ }
   /** amit be lehet gyujteni*/ if(reds+blues>most) {most=reds+blues; cout << most <<"="<<reds<<"+"<<blues<<endl;}
                                red_first=false;        /// kov kor ugye kekkel fog kezdodni
                                blues=0; reds=0;                 /// es az utoljara szamoltakat megtartjuk, az eloszor szamoltakat szamoljuk ujra
                                neck=neck->get_before();    /// a 2. while utan egy piros gyongyon lesz, ezer kell visszalepni, hogy a kov while

                                never_ending=0;
                                while(neck->is_blue() && never_ending<nr*2)       /// mukodjon.
                                {
                                    neck=neck->get_before();    /// itt bele lehet futni egy vegtelen ciklusba, ha csak 1 szin van!
                                    never_ending++;
                                }/// most egy piros gyongyon van ezert
                                neck=neck->get_next();

                    break;

                    case false:

                                while(neck->is_blue())
                                {
                                    blues++;
                                    neck=neck->get_next();
                                }
                                while(neck->is_red())
                                {
                                    reds++;
                                    neck=neck->get_next();
                                }
                                if(reds+blues>most) {most=reds+blues; cout << most <<"="<<reds<<"+"<<blues<<endl;}
                                red_first=true;
                                reds=0; blues=0;
                                neck=neck->get_before();
                                never_ending=0;
                                while(neck->is_red() && never_ending<nr*2)
                                {
                                    never_ending++;
                                }
                                neck=neck->get_next();
                    break;
                }

            }
    }
    if(most>nr) cout << nr << endl;
    else cout << endl << most << endl;


    return 0;
}
