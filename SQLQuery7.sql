CREATE TABLE Frutas (
    Id INT IDENTITY(1,1) PRIMARY KEY,  -- chave prim�ria, auto-incrementa a partir de 1
    Nome VARCHAR(100) NOT NULL,        -- nome da fruta, texto at� 100 caracteres
    Quantidade INT NOT NULL            -- quantidade no estoque
);

