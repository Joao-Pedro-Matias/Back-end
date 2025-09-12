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
        Content = "Andrezao amante de traveco";
    }

    //Métodos

    public string Open() {

        char[] size = Content.ToCharArray();
        Size = size.Length * 8;

        return $" Nome do Texto: {Name}\n Tamanho: {Size} bits\n Conteúdo:\n {Content}\n";
        
    }

    public bool Edit(string edit) {

        Content += edit
    }
}
