![senai_logo](https://transparencia.sp.senai.br/Content/img/logo-senai.png)

# Exercícios de aula 01: POO + UML (parte 1)

Profº.: Cainã Antunes Silva  
Faculdade de Tecnologia **SENAI Sorocaba**  
Tecnólogo em Análise e Desenvolvimento de Sistemas (ADS)
___


> O objetivo desta aula é exercitar a habilidade de abstrair objetos em classes utilizando-se notações em UML.  

O paradigma de desenvolvimento de software intitulado Programação Orientada à Objetos é uma ferramenta poderosa que auxilia na construção de sistemas complexos. A abstração é um recurso indispensável para programadores que almejam dominar esta poderosa técnica de programação. Além disso o uso de diagramas UML é indispensavel para representar estas abstrações e guiar os desenvolvidores na hora da implementação.

Para mais informações acesse [Aula 01: Paradigma POO.](https://cainaantunes.notion.site/Aula-01-Paradigma-POO-23fbde521b3b80149a11f08e9d1eac02?source=copy_link)

***

1. **Carro:**<br>
Pense em um carro do cotidiano. Como ele pode ser descrito em termos de informação e comportamento?
Crie um diagrama de classe UML que represente essa entidade.

    ```mermaid
            classDiagram
        class Carro {
            -Cor: string
            -Velocidade: int
            +Acelerar(incremento: int): void
            +Frear(decremento: int): void
        }
    ```
   
2. **Cachorro:**<br>
Um cachorro de estimação pode ser identificado de várias formas e interagir com o ambiente. <br>
Represente essa ideia por meio de uma classe UML com atributos e métodos que façam sentido.

    ```mermaid
        classDiagram
        class Cachorro {
            -Raca: string
            -Porte: int
            -Cor: string
            -Nome: string
            -Latindo:bool
            +Latir(): void
            +Andar(direcao: string, passos:int): void
            +Pular(altura: int): void
        

        }
    ```

3. **Jogador de Videogame:**<br>
Considere um personagem controlado por um jogador em um jogo eletrônico. Quais informações podem ser armazenadas sobre ele? Que ações ele pode realizar?<br>
Modele uma classe que represente esse jogador.

    ```mermaid
        classDiagram
        class Player {
            -Nick: string
            -Altura: float
            -Cor: string
            -Roupa: int
            +Andar(direcao: string): void
            +Correr(direcao: string): void
            +Comer(quantidade: int): int

        }
    ```

4. **Produto de Loja:**<br>
Imagine um produto exposto em uma loja, seja física ou virtual. Quais dados são importantes para representá-lo? Que tipo de operações podem ser feitas sobre ele?<br>
Crie uma classe UML com base nessas reflexões.

    ```mermaid
        classDiagram
        class Nome do Produto {
            -Id: int
            -Nome: string
            -Quantidade: int
            -Tipo: string
            +AdicionarCarrinho(): void
            +Comprar(): void         
        }
    ```

5. **Livro:**<br>
Pense em como você descreveria um livro para um sistema digital (como uma biblioteca ou livraria online).
Quais dados o sistema precisaria guardar sobre esse livro? Que ações poderiam ser realizadas com ele?

    ```mermaid
        classDiagram
        class Livro {
            -Id: int
            -Título: string
            -Quantidade: int
            -Autor: string
            -Editor: string
            +Comprar(): void
            +Consultar(): string
        }
    ```

6. **Conta Bancária:**<br>
Considere como um sistema bancário representa uma conta de um cliente. Quais dados são essenciais? Que operações a conta deve suportar?<br>
Modele isso como uma classe UML.

    ```mermaid
        classDiagram
        class Banco {
            -Número da conta: long
            -Proprietário: string
            -Chave: int
            -Saldo: float
            +FazerPix(valor:float):void
            +GuardarDinheiro(valor:float):void
        }
    ```

7. **Usuário de Sistema:**<br>
Um sistema informatizado permite que pessoas se cadastrem, acessem recursos e atualizem suas informações.<br>
Crie uma classe que represente esse "usuário" de forma genérica, com seus atributos e comportamentos.

    ```mermaid
        classDiagram
        class Usuário {
            -Id: int
            -Nome: string
            -Email: string
            -CPF: int
            -Nascimento: int
            +AtualizarDados(dados:string/int): void
            +ExcluirConta(): void
        }
    ```

8. **Pedido de Compra:**<br>
Em um sistema de compras online ou presencial, como um pedido de compra pode ser estruturado em uma classe?<br>
Pense em quais informações estão envolvidas em um pedido e quais ações podem ser realizadas com ele.

    ```mermaid
        classDiagram
        class Pedido {
            -Id:int
            -Produto: string
            -Data: int
            -Vendedor: string
            -Valor:double
            +Comprar(): void
            +AdicionarCarrinho(): void
            +Analisar(): void
        }
    ```

9. **Sessão de Login:**<br>
Quando um usuário entra em um sistema, uma sessão é iniciada. Como essa sessão poderia ser representada em uma classe?<br>
Reflita sobre os dados e comportamentos necessários para modelar esse conceito.

    ```mermaid
        classDiagram
        class Login {
            -Nome: string
            -Senha: string
            -Email: string            
            +Login(): void
        }
    ```

10. **Repositório Git:**<br>
Pense em como um sistema como o GitHub representa um repositório de código. Quais dados ele precisa manter? Que ações podem ser realizadas sobre ele?<br>
Modele esse objeto como uma classe UML.

    ```mermaid
        classDiagram
        class Repositório {
            -NomeDoRepositorio: string
            -Id: int
            -NomeDoAutor: string
            +Clonar(): void
            +Atualizar(): void
            +SubirArquivos(): void
        }
    ```

