﻿CREATE TABLE RNA_REGIONI(
COD_REGIONE CHAR(2) NOT NULL,
COD_REGIONE_RNA VARCHAR(10) NULL,
DENOMINAZIONE VARCHAR(50),
FOREIGN KEY (COD_REGIONE) REFERENCES REGIONI(CODICE),
CONSTRAINT RNA_REGIONI_PK PRIMARY KEY CLUSTERED 
(
	COD_REGIONE ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY]