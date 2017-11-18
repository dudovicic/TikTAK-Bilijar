import clr
clr.AddReference('System.Windows.Forms')
from System.Windows.Forms import *
clr.AddReference('System.Drawing')
from System.Drawing import Point

def Dodaj(self):
   
    menuStrip = MenuStrip(Name="Main MenuStrip", Dock=DockStyle.Top)
    fileMenu  = ToolStripMenuItem(Name="File Menu", Text='&File')
    fileMenu1  = ToolStripMenuItem(Name="File Menu", Text='&Help')
    
    openMenuItem1  = ToolStripMenuItem(Name="New game", Text='&New game')
    openMenuItem2  = ToolStripMenuItem(Name="Result", Text='&Result')
    openMenuItem3  = ToolStripMenuItem(Name="Exit", Text='&Exit')
    openMenuItem4  = ToolStripMenuItem(Name="About", Text='&About game')

    openMenuItem1.Click += self.onNewGame
    openMenuItem2.Click += self.onOpen
    openMenuItem3.Click += self.onExit
    openMenuItem4.Click += self.onOpenAbout

    fileMenu.DropDownItems.Add(openMenuItem1)
    fileMenu.DropDownItems.Add(openMenuItem2)
    fileMenu.DropDownItems.Add(openMenuItem3)
    fileMenu1.DropDownItems.Add(openMenuItem4)

    menuStrip.Items.Add(fileMenu)
    menuStrip.Items.Add(fileMenu1)
    self.Controls.Add(menuStrip) 

def Rezultat(vrijednost1, vrijednost2, vrijednost3, vrijednost4, vrijednost5):
    return vrijednost1 + vrijednost2 + vrijednost3 + vrijednost4 + vrijednost5
    f = open('C:/Users/ACER7/Desktop/TikTAK/rezultat.txt', 'w')
    f.write('vrijednost1 + vrijednost2 + vrijednost3 + vrijednost4 + vrijednost5')
    f.close()



