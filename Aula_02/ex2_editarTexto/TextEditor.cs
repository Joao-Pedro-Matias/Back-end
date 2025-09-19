public class TextEditor
{
    //Atributos

    private string Name;

    private int Size;

    private string Content;

    // Construtores

    public TextEditor(string name) {
        Name = name;
        Size = 0;
        Content = "";
    }

    //Métodos

    public string Open() {

        char[] size = Content.ToCharArray();
        Size = size.Length * 8;

        return $"\nNome do Texto: {Name}\n Tamanho: {Size} bits\n Conteúdo: {Content}\n";
        
    }

    public bool Edit(string edit) {

        Content += edit;
        return true;
    }


    public bool Rename(string newName) {
        if (newName == null)
            return false;

        Name = newName;
        return true;
   }


   public void Clear() {

    Content = "";

   }

}