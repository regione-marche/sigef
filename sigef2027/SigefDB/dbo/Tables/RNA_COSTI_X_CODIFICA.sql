﻿CREATE TABLE RNA_COSTI_X_CODIFICA(
ID_COSTI_X_CODIFICA INT IDENTITY(1,1) NOT NULL,
ID_CODIFICA_INVESTIMENTO INT NOT NULL FOREIGN KEY REFERENCES CODIFICA_INVESTIMENTO(ID_CODIFICA_INVESTIMENTO),
COD_TIPO_SPESA INT NULL FOREIGN KEY REFERENCES RNA_TIPO_COSTO_AMMISSIBILE(COD_TIPO_SPESA),
CONSTRAINT ID_RNA_CODIFICA_INV_PK PRIMARY KEY CLUSTERED 
(
	ID_COSTI_X_CODIFICA ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY]