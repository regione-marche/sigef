<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:xs="http://www.w3.org/2001/XMLSchema" exclude-result-prefixes="xs">
	<xsl:output method="xml" encoding="UTF-8" indent="no"/>
	<xsl:template match="/">
		<INVIO xmlns="http://www.rna.gov.it/invio" xmlns:age="http://www.rna.gov.it/agevolazioni_erogate_restituite" xmlns:benef="http://www.rna.gov.it/beneficiario" xmlns:comp="http://www.rna.gov.it/componente_aiuto" xmlns:conc="http://www.rna.gov.it/concessione" xmlns:costo="http://www.rna.gov.it/costo" xmlns:cup="http://www.rna.gov.it/info_cup" xmlns:local="http://www.rna.gov.it/localizzazione" xmlns:rend="http://www.rna.gov.it/rendicontazione" xmlns:dett="http://www.rna.gov.it/rendicontazione_dettaglio" xmlns:strum="http://www.rna.gov.it/strumento_aiuto">
			<xsl:for-each select="*[local-name()='NewDataSet' and namespace-uri()='']/*[local-name()='Table' and namespace-uri()='']/*[local-name()='COD_BANDO' and namespace-uri()='']">
				<COD_BANDO>
					<xsl:value-of select="string(floor(number(string(.))))"/>
				</COD_BANDO>
			</xsl:for-each>
			<xsl:for-each select="*[local-name()='NewDataSet' and namespace-uri()='']/*[local-name()='Table' and namespace-uri()='']/*[local-name()='NOTIFICA_ELABORAZIONE_RICHIESTA' and namespace-uri()='']">
				<NOTIFICA_ELABORAZIONE_RICHIESTA>
					<xsl:value-of select="string(.)"/>
				</NOTIFICA_ELABORAZIONE_RICHIESTA>
			</xsl:for-each>
			<CONCESSIONI>
				<xsl:for-each select="*[local-name()='NewDataSet' and namespace-uri()='']">
					<xsl:variable name="var36" select="."/>
					<xsl:for-each select="*[local-name()='Table1' and namespace-uri()='']">
						<xsl:variable name="var35" select="."/>
						<CONCESSIONE>
							<xsl:for-each select="*[local-name()='TITOLO_PROGETTO' and namespace-uri()='']">
								<conc:TITOLO_PROGETTO xsl:exclude-result-prefixes="conc">
									<xsl:value-of select="string(.)"/>
								</conc:TITOLO_PROGETTO>
							</xsl:for-each>
							<xsl:for-each select="*[local-name()='DESCRIZIONE_PROGETTO' and namespace-uri()='']">
								<conc:DESCRIZIONE_PROGETTO xsl:exclude-result-prefixes="conc">
									<xsl:value-of select="string(.)"/>
								</conc:DESCRIZIONE_PROGETTO>
							</xsl:for-each>
							<xsl:for-each select="*[local-name()='COD_TIPO_INIZIATIVA' and namespace-uri()='']">
								<conc:COD_TIPO_INIZIATIVA xsl:exclude-result-prefixes="conc">
									<xsl:value-of select="string(.)"/>
								</conc:COD_TIPO_INIZIATIVA>
							</xsl:for-each>
							<xsl:for-each select="*[local-name()='CUP_CHECK_RICHIESTA' and namespace-uri()='']">
								<conc:CUP_CHECK_RICHIESTA xsl:exclude-result-prefixes="conc">
									<xsl:value-of select="string(floor(number(string(.))))"/>
								</conc:CUP_CHECK_RICHIESTA>
							</xsl:for-each>
							<xsl:for-each select="*[local-name()='DATA_DOMANDA' and namespace-uri()='']">
								<conc:DATA_DOMANDA xsl:exclude-result-prefixes="conc">
									<xsl:value-of select="substring-before(string(.), 'T')"/>
								</conc:DATA_DOMANDA>
							</xsl:for-each>
							<xsl:for-each select="*[local-name()='DATA_INIZIO_PROGETTO' and namespace-uri()='']">
								<conc:DATA_INIZIO_PROGETTO xsl:exclude-result-prefixes="conc">
									<xsl:value-of select="substring-before(string(.), 'T')"/>
								</conc:DATA_INIZIO_PROGETTO>
							</xsl:for-each>
							<xsl:for-each select="*[local-name()='DATA_FINE_PROGETTO' and namespace-uri()='']">
								<conc:DATA_FINE_PROGETTO xsl:exclude-result-prefixes="conc">
									<xsl:value-of select="substring-before(string(.), 'T')"/>
								</conc:DATA_FINE_PROGETTO>
							</xsl:for-each>
							<xsl:for-each select="*[local-name()='LINK_TRASPARENZA' and namespace-uri()='']">
								<conc:LINK_TRASPARENZA xsl:exclude-result-prefixes="conc">
									<xsl:value-of select="string(.)"/>
								</conc:LINK_TRASPARENZA>
							</xsl:for-each>
							<xsl:for-each select="*[local-name()='ID_CONCESSIONE_GEST' and namespace-uri()='']">
								<conc:ID_CONCESSIONE_GEST xsl:exclude-result-prefixes="conc">
									<xsl:value-of select="string(.)"/>
								</conc:ID_CONCESSIONE_GEST>
							</xsl:for-each>
							<xsl:for-each select="*[local-name()='FLAG_ATTO_CONCESSIONE' and namespace-uri()='']">
								<conc:FLAG_ATTO_CONCESSIONE xsl:exclude-result-prefixes="conc">
									<xsl:value-of select="string(.)"/>
								</conc:FLAG_ATTO_CONCESSIONE>
							</xsl:for-each>
							<xsl:for-each select="*[local-name()='DATA_CONCESSIONE' and namespace-uri()='']">
								<conc:DATA_CONCESSIONE xsl:exclude-result-prefixes="conc">
									<xsl:value-of select="substring-before(string(.), 'T')"/>
								</conc:DATA_CONCESSIONE>
							</xsl:for-each>
							<xsl:for-each select="*[local-name()='CODICE_LOCALE_PROGETTO' and namespace-uri()='']">
								<conc:CODICE_LOCALE_PROGETTO xsl:exclude-result-prefixes="conc">
									<xsl:value-of select="string(.)"/>
								</conc:CODICE_LOCALE_PROGETTO>
							</xsl:for-each>
							<xsl:for-each select="*[local-name()='NOTE_CONCESSIONE' and namespace-uri()='']">
								<conc:NOTE_CONCESSIONE xsl:exclude-result-prefixes="conc">
									<xsl:value-of select="string(.)"/>
								</conc:NOTE_CONCESSIONE>
							</xsl:for-each>
							<xsl:for-each select="*[local-name()='COD_STATO_CONCESSIONE' and namespace-uri()='']">
								<conc:COD_STATO_CONCESSIONE_GEST xsl:exclude-result-prefixes="conc">
									<xsl:value-of select="string(.)"/>
								</conc:COD_STATO_CONCESSIONE_GEST>
							</xsl:for-each>
							<xsl:for-each select="$var36/*[local-name()='Table2' and namespace-uri()='']">
								<xsl:variable name="var5" select="."/>
								<xsl:variable name="var4">
									<xsl:for-each select="$var35/*[local-name()='ID_PROGETTO' and namespace-uri()='']">
										<xsl:variable name="var3" select="."/>
										<xsl:for-each select="$var5/*[local-name()='ID_PROGETTO' and namespace-uri()='']">
											<xsl:variable name="var2" select="."/>
											<xsl:for-each select="$var35/*[local-name()='ID_IMPRESA' and namespace-uri()='']">
												<xsl:variable name="var1" select="."/>
												<xsl:for-each select="$var5/*[local-name()='ID_IMPRESA' and namespace-uri()=''][((string(floor(number(string($var3)))) = string($var2)) and (floor(number(string($var1))) = floor(number(string(.)))))]">
													<xsl:value-of select="true()"/>
												</xsl:for-each>
											</xsl:for-each>
										</xsl:for-each>
									</xsl:for-each>
								</xsl:variable>
								<xsl:if test="string(boolean(string($var4))) != 'false'">
									<conc:BENEFICIARIO xsl:exclude-result-prefixes="conc">
										<xsl:for-each select="*[local-name()='COD_TIPO_SOGGETTO' and namespace-uri()='']">
											<benef:COD_TIPO_SOGGETTO xsl:exclude-result-prefixes="benef">
												<xsl:value-of select="string(.)"/>
											</benef:COD_TIPO_SOGGETTO>
										</xsl:for-each>
										<xsl:for-each select="*[local-name()='CODICE_FISCALE' and namespace-uri()='']">
											<benef:CODICE_FISCALE xsl:exclude-result-prefixes="benef">
												<xsl:value-of select="string(.)"/>
											</benef:CODICE_FISCALE>
										</xsl:for-each>
										<xsl:for-each select="*[local-name()='DENOMINAZIONE' and namespace-uri()='']">
											<benef:DENOMINAZIONE xsl:exclude-result-prefixes="benef">
												<xsl:value-of select="string(.)"/>
											</benef:DENOMINAZIONE>
										</xsl:for-each>
										<xsl:for-each select="*[local-name()='FINE_ESERCIZIO_FINANZIARIO' and namespace-uri()='']">
											<benef:FINE_ESERCIZIO_FINANZIARIO xsl:exclude-result-prefixes="benef">
												<xsl:value-of select="string(.)"/>
											</benef:FINE_ESERCIZIO_FINANZIARIO>
										</xsl:for-each>
										<xsl:for-each select="*[local-name()='COD_DIMENSIONE_IMPRESA' and namespace-uri()='']">
											<benef:COD_DIMENSIONE_IMPRESA xsl:exclude-result-prefixes="benef">
												<xsl:value-of select="string(floor(number(string(.))))"/>
											</benef:COD_DIMENSIONE_IMPRESA>
										</xsl:for-each>
										<xsl:for-each select="*[local-name()='COD_TIPO_ATTIVITA_PREVALENTE' and namespace-uri()='']">
											<benef:COD_TIPO_ATTIVITA_PREVALENTE xsl:exclude-result-prefixes="benef">
												<xsl:value-of select="string(.)"/>
											</benef:COD_TIPO_ATTIVITA_PREVALENTE>
										</xsl:for-each>
										<xsl:for-each select="*[local-name()='COD_FORMA_GIURIDICA' and namespace-uri()='']">
											<benef:COD_FORMA_GIURIDICA xsl:exclude-result-prefixes="benef">
												<xsl:value-of select="string(.)"/>
											</benef:COD_FORMA_GIURIDICA>
										</xsl:for-each>
										<benef:SEDE_LEGALE xsl:exclude-result-prefixes="benef">
											<xsl:for-each select="*[local-name()='INDIRIZZO' and namespace-uri()='']">
												<benef:INDIRIZZO xsl:exclude-result-prefixes="benef">
													<xsl:value-of select="string(.)"/>
												</benef:INDIRIZZO>
											</xsl:for-each>
											<xsl:for-each select="*[local-name()='COD_NAZIONE' and namespace-uri()='']">
												<benef:COD_NAZIONE xsl:exclude-result-prefixes="benef">
													<xsl:value-of select="string(.)"/>
												</benef:COD_NAZIONE>
											</xsl:for-each>
											<xsl:for-each select="*[local-name()='COD_COMUNE' and namespace-uri()='']">
												<benef:COD_COMUNE xsl:exclude-result-prefixes="benef">
													<xsl:value-of select="string(.)"/>
												</benef:COD_COMUNE>
											</xsl:for-each>
											<xsl:for-each select="*[local-name()='COMUNE' and namespace-uri()='']">
												<benef:COMUNE xsl:exclude-result-prefixes="benef">
													<xsl:value-of select="string(.)"/>
												</benef:COMUNE>
											</xsl:for-each>
											<xsl:for-each select="*[local-name()='CAP' and namespace-uri()='']">
												<benef:CAP xsl:exclude-result-prefixes="benef">
													<xsl:value-of select="string(.)"/>
												</benef:CAP>
											</xsl:for-each>
										</benef:SEDE_LEGALE>
									</conc:BENEFICIARIO>
								</xsl:if>
							</xsl:for-each>
							<conc:LOCALIZZAZIONI xsl:exclude-result-prefixes="conc">
								<xsl:for-each select="$var36/*[local-name()='Table3' and namespace-uri()='']">
									<xsl:variable name="var10" select="."/>
									<xsl:variable name="var9">
										<xsl:for-each select="$var35/*[local-name()='ID_PROGETTO' and namespace-uri()='']">
											<xsl:variable name="var8" select="."/>
											<xsl:for-each select="$var10/*[local-name()='ID_PROGETTO' and namespace-uri()='']">
												<xsl:variable name="var7" select="."/>
												<xsl:for-each select="$var35/*[local-name()='ID_IMPRESA' and namespace-uri()='']">
													<xsl:variable name="var6" select="."/>
													<xsl:for-each select="$var10/*[local-name()='ID_IMPRESA' and namespace-uri()=''][((string(floor(number(string($var8)))) = string($var7)) and (floor(number(string($var6))) = floor(number(string(.)))))]">
														<xsl:value-of select="true()"/>
													</xsl:for-each>
												</xsl:for-each>
											</xsl:for-each>
										</xsl:for-each>
									</xsl:variable>
									<xsl:if test="string(boolean(string($var9))) != 'false'">
										<conc:LOCALIZZAZIONE xsl:exclude-result-prefixes="conc">
											<xsl:for-each select="*[local-name()='ID_LOCA_GEST' and namespace-uri()='']">
												<local:ID_LOCA_GEST xsl:exclude-result-prefixes="local">
													<xsl:value-of select="string(.)"/>
												</local:ID_LOCA_GEST>
											</xsl:for-each>
											<xsl:for-each select="*[local-name()='COD_REGIONE' and namespace-uri()='']">
												<local:COD_REGIONE xsl:exclude-result-prefixes="local">
													<xsl:value-of select="string(.)"/>
												</local:COD_REGIONE>
											</xsl:for-each>
											<xsl:for-each select="*[local-name()='CHECK_LOCALIZZAZIONE' and namespace-uri()='']">
												<local:CHECK_LOCALIZZAZIONE xsl:exclude-result-prefixes="local">
													<xsl:value-of select="string(.)"/>
												</local:CHECK_LOCALIZZAZIONE>
											</xsl:for-each>
											<xsl:for-each select="*[local-name()='COD_COMUNE' and namespace-uri()='']">
												<local:COD_COMUNE xsl:exclude-result-prefixes="local">
													<xsl:value-of select="string(.)"/>
												</local:COD_COMUNE>
											</xsl:for-each>
											<xsl:for-each select="*[local-name()='COMUNE' and namespace-uri()='']">
												<local:COMUNE xsl:exclude-result-prefixes="local">
													<xsl:value-of select="string(.)"/>
												</local:COMUNE>
											</xsl:for-each>
											<xsl:for-each select="*[local-name()='CAP' and namespace-uri()='']">
												<local:CAP xsl:exclude-result-prefixes="local">
													<xsl:value-of select="string(.)"/>
												</local:CAP>
											</xsl:for-each>
											<xsl:for-each select="*[local-name()='INDIRIZZO' and namespace-uri()='']">
												<local:INDIRIZZO xsl:exclude-result-prefixes="local">
													<xsl:value-of select="string(.)"/>
												</local:INDIRIZZO>
											</xsl:for-each>
										</conc:LOCALIZZAZIONE>
									</xsl:if>
								</xsl:for-each>
							</conc:LOCALIZZAZIONI>
							<conc:COSTI xsl:exclude-result-prefixes="conc">
								<xsl:for-each select="$var36/*[local-name()='Table4' and namespace-uri()='']">
									<xsl:variable name="var15" select="."/>
									<xsl:variable name="var14">
										<xsl:for-each select="$var35/*[local-name()='ID_PROGETTO' and namespace-uri()='']">
											<xsl:variable name="var13" select="."/>
											<xsl:for-each select="$var15/*[local-name()='ID_PROGETTO' and namespace-uri()='']">
												<xsl:variable name="var12" select="."/>
												<xsl:for-each select="$var35/*[local-name()='ID_IMPRESA' and namespace-uri()='']">
													<xsl:variable name="var11" select="."/>
													<xsl:for-each select="$var15/*[local-name()='ID_IMPRESA' and namespace-uri()=''][((string(floor(number(string($var13)))) = string($var12)) and (floor(number(string($var11))) = floor(number(string(.)))))]">
														<xsl:value-of select="true()"/>
													</xsl:for-each>
												</xsl:for-each>
											</xsl:for-each>
										</xsl:for-each>
									</xsl:variable>
									<xsl:if test="string(boolean(string($var14))) != 'false'">
										<conc:COSTO xsl:exclude-result-prefixes="conc">
											<xsl:for-each select="*[local-name()='ID_COSTO_GEST' and namespace-uri()='']">
												<costo:ID_COSTO_GEST xsl:exclude-result-prefixes="costo">
													<xsl:value-of select="string(.)"/>
												</costo:ID_COSTO_GEST>
											</xsl:for-each>
											<xsl:for-each select="*[local-name()='COD_TIPO_COSTO' and namespace-uri()='']">
												<costo:COD_TIPO_COSTO xsl:exclude-result-prefixes="costo">
													<xsl:value-of select="string(.)"/>
												</costo:COD_TIPO_COSTO>
											</xsl:for-each>
											<xsl:for-each select="*[local-name()='IMPORTO_AMMESSO' and namespace-uri()='']">
												<costo:IMPORTO_AMMESSO xsl:exclude-result-prefixes="costo">
													<xsl:value-of select="string(number(string(.)))"/>
												</costo:IMPORTO_AMMESSO>
											</xsl:for-each>
										</conc:COSTO>
									</xsl:if>
								</xsl:for-each>
							</conc:COSTI>
							<conc:COMPONENTI_AIUTI xsl:exclude-result-prefixes="conc">
								<xsl:for-each select="$var36/*[local-name()='Table5' and namespace-uri()='']">
									<xsl:variable name="var34" select="."/>
									<xsl:variable name="var16" select="$var35/*[local-name()='ID_PROGETTO' and namespace-uri()='']"/>
									<xsl:variable name="var20">
										<xsl:for-each select="$var16">
											<xsl:variable name="var19" select="."/>
											<xsl:for-each select="$var34/*[local-name()='ID_PROGETTO' and namespace-uri()='']">
												<xsl:variable name="var18" select="."/>
												<xsl:for-each select="$var35/*[local-name()='ID_IMPRESA' and namespace-uri()='']">
													<xsl:variable name="var17" select="."/>
													<xsl:for-each select="$var34/*[local-name()='ID_IMPRESA' and namespace-uri()=''][((string(floor(number(string($var19)))) = string($var18)) and (floor(number(string($var17))) = floor(number(string(.)))))]">
														<xsl:value-of select="true()"/>
													</xsl:for-each>
												</xsl:for-each>
											</xsl:for-each>
										</xsl:for-each>
									</xsl:variable>
									<xsl:if test="string(boolean(string($var20))) != 'false'">
										<xsl:variable name="var21" select="*[local-name()='COD_OBIETTIVO' and namespace-uri()='']"/>
										<conc:COMPONENTE_AIUTO xsl:exclude-result-prefixes="conc">
											<xsl:for-each select="*[local-name()='ID_COMP_AIUTO_GEST' and namespace-uri()='']">
												<comp:ID_COMP_AIUTO_GEST xsl:exclude-result-prefixes="comp">
													<xsl:value-of select="string(.)"/>
												</comp:ID_COMP_AIUTO_GEST>
											</xsl:for-each>
											<xsl:for-each select="*[local-name()='DESCR_BREVE' and namespace-uri()='']">
												<comp:DESCR_BREVE xsl:exclude-result-prefixes="comp">
													<xsl:value-of select="string(.)"/>
												</comp:DESCR_BREVE>
											</xsl:for-each>
											<xsl:for-each select="*[local-name()='COD_TIPO_PROCEDIMENTO' and namespace-uri()='']">
												<comp:COD_TIPO_PROCEDIMENTO xsl:exclude-result-prefixes="comp">
													<xsl:value-of select="string(floor(number(string(.))))"/>
												</comp:COD_TIPO_PROCEDIMENTO>
											</xsl:for-each>
											<xsl:for-each select="*[local-name()='CODICE_REGOLAMENTO' and namespace-uri()='']">
												<comp:CODICE_REGOLAMENTO xsl:exclude-result-prefixes="comp">
													<xsl:value-of select="string(.)"/>
												</comp:CODICE_REGOLAMENTO>
											</xsl:for-each>
											<xsl:for-each select="$var21">
												<comp:COD_OBIETTIVO xsl:exclude-result-prefixes="comp">
													<xsl:value-of select="string(number(string(.)))"/>
												</comp:COD_OBIETTIVO>
											</xsl:for-each>
											<xsl:for-each select="*[local-name()='CODICE_SETTORE' and namespace-uri()='']">
												<comp:CODICE_SETTORE xsl:exclude-result-prefixes="comp">
													<xsl:value-of select="string(.)"/>
												</comp:CODICE_SETTORE>
											</xsl:for-each>
											<xsl:for-each select="*[local-name()='CUMULABILITA' and namespace-uri()='']">
												<comp:CUMULABILITA xsl:exclude-result-prefixes="comp">
													<xsl:value-of select="string(.)"/>
												</comp:CUMULABILITA>
											</xsl:for-each>
											<xsl:for-each select="*[local-name()='FLAG_CE' and namespace-uri()='']">
												<comp:FLAG_CE xsl:exclude-result-prefixes="comp">
													<xsl:value-of select="string(.)"/>
												</comp:FLAG_CE>
											</xsl:for-each>
											<xsl:for-each select="$var36/*[local-name()='Table6' and namespace-uri()='']">
												<xsl:variable name="var26" select="."/>
												<xsl:variable name="var25">
													<xsl:for-each select="$var16">
														<xsl:variable name="var24" select="."/>
														<xsl:for-each select="$var26/*[local-name()='ID_PROGETTO' and namespace-uri()='']">
															<xsl:variable name="var23" select="."/>
															<xsl:for-each select="$var35/*[local-name()='ID_IMPRESA' and namespace-uri()='']">
																<xsl:variable name="var22" select="."/>
																<xsl:for-each select="$var26/*[local-name()='ID_IMPRESA' and namespace-uri()=''][((floor(number(string($var24))) = floor(number(string($var23)))) and (floor(number(string($var22))) = floor(number(string(.)))))]">
																	<xsl:value-of select="true()"/>
																</xsl:for-each>
															</xsl:for-each>
														</xsl:for-each>
													</xsl:for-each>
												</xsl:variable>
												<xsl:if test="string(boolean(string($var25))) != 'false'">
													<comp:COD_ATECO_LIST xsl:exclude-result-prefixes="comp">
														<xsl:for-each select="*[local-name()='COD_ATECO' and namespace-uri()='']">
															<comp:COD_ATECO xsl:exclude-result-prefixes="comp">
																<xsl:value-of select="string(.)"/>
															</comp:COD_ATECO>
														</xsl:for-each>
													</comp:COD_ATECO_LIST>
												</xsl:if>
											</xsl:for-each>
											<comp:STRUMENTI_AIUTO xsl:exclude-result-prefixes="comp">
												<xsl:for-each select="$var36/*[local-name()='Table7' and namespace-uri()='']">
													<xsl:variable name="var33" select="."/>
													<xsl:variable name="var32">
														<xsl:for-each select="$var16">
															<xsl:variable name="var31" select="."/>
															<xsl:for-each select="$var33/*[local-name()='ID_PROGETTO' and namespace-uri()='']">
																<xsl:variable name="var30" select="."/>
																<xsl:for-each select="$var35/*[local-name()='ID_IMPRESA' and namespace-uri()='']">
																	<xsl:variable name="var29" select="."/>
																	<xsl:for-each select="$var33/*[local-name()='ID_IMPRESA' and namespace-uri()='']">
																		<xsl:variable name="var28" select="."/>
																		<xsl:for-each select="$var21">
																			<xsl:variable name="var27" select="."/>
																			<xsl:for-each select="$var33/*[local-name()='COD_OBIETTIVO' and namespace-uri()=''][(((string(floor(number(string($var31)))) = string($var30)) and (floor(number(string($var29))) = floor(number(string($var28))))) and (string($var27) = string(.)))]">
																				<xsl:value-of select="true()"/>
																			</xsl:for-each>
																		</xsl:for-each>
																	</xsl:for-each>
																</xsl:for-each>
															</xsl:for-each>
														</xsl:for-each>
													</xsl:variable>
													<xsl:if test="string(boolean(string($var32))) != 'false'">
														<comp:STRUMENTO_AIUTO xsl:exclude-result-prefixes="comp">
															<xsl:for-each select="*[local-name()='ID_STRUM_AIUTO_GEST' and namespace-uri()='']">
																<strum:ID_STRUM_AIUTO_GEST xsl:exclude-result-prefixes="strum">
																	<xsl:value-of select="string(.)"/>
																</strum:ID_STRUM_AIUTO_GEST>
															</xsl:for-each>
															<xsl:for-each select="*[local-name()='COD_TIPO_STRUMENTO_AIUTO' and namespace-uri()='']">
																<strum:COD_TIPO_STRUMENTO_AIUTO xsl:exclude-result-prefixes="strum">
																	<xsl:value-of select="string(floor(number(string(.))))"/>
																</strum:COD_TIPO_STRUMENTO_AIUTO>
															</xsl:for-each>
															<xsl:for-each select="*[local-name()='IMPORTO_NOMINALE' and namespace-uri()='']">
																<strum:IMPORTO_NOMINALE xsl:exclude-result-prefixes="strum">
																	<xsl:value-of select="string(number(string(.)))"/>
																</strum:IMPORTO_NOMINALE>
															</xsl:for-each>
															<xsl:for-each select="*[local-name()='IMPORTO_AGEVOLAZIONE' and namespace-uri()='']">
																<strum:IMPORTO_AGEVOLAZIONE xsl:exclude-result-prefixes="strum">
																	<xsl:value-of select="string(number(string(.)))"/>
																</strum:IMPORTO_AGEVOLAZIONE>
															</xsl:for-each>
															<xsl:for-each select="*[local-name()='INTENSITA_AIUTO' and namespace-uri()='']">
																<strum:INTENSITA_AIUTO xsl:exclude-result-prefixes="strum">
																	<xsl:value-of select="string(number(string(.)))"/>
																</strum:INTENSITA_AIUTO>
															</xsl:for-each>
														</comp:STRUMENTO_AIUTO>
													</xsl:if>
												</xsl:for-each>
											</comp:STRUMENTI_AIUTO>
										</conc:COMPONENTE_AIUTO>
									</xsl:if>
								</xsl:for-each>
							</conc:COMPONENTI_AIUTI>
						</CONCESSIONE>
					</xsl:for-each>
				</xsl:for-each>
			</CONCESSIONI>
		</INVIO>
	</xsl:template>
</xsl:stylesheet>
