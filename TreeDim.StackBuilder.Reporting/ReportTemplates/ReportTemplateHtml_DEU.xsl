<?xml version="1.0" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="report">
    <html>
      <head>
        <title>
          <xsl:value-of select="name"/> report
        </title>
        <style type="text/css">
          .style1
          {
          width: 100%;
          }
          .style2
          {
          background-color: #CCCCCC;
          }
          .style3
          {
          }
        </style>
      </head>
      <body>
        <h4 style="text-align:center">
          Bericht erstellt von treeDiM StackBuilder
        </h4>
        <table border="0" cellpadding="3">
          <tr>
            <td class="style2">
              <b>Dokument</b>
            </td>
            <td class="style3" colspan="2">
              <xsl:value-of select="name"/>
            </td>
          </tr>
          <tr>
            <td class="style2">
              <b>Beschreibung</b>
            </td>
            <td class="style3" colspan="2">
              <xsl:value-of select="description"/>
            </td>
          </tr>
          <tr>
            <td class="style2">
              <b>Datum</b>
            </td>
            <td class="style3" colspan="1">
              <xsl:value-of select="dateOfCreation"/>
            </td>
            <td class="style2">
              <b>Autor</b>
            </td>
            <td class="style3" colspan="1">
              <xsl:value-of select="author"/>
            </td>
          </tr>
        </table>
        <xsl:apply-templates select="caseAnalysis"/>
        <xsl:apply-templates select="palletAnalysis"/>
        <xsl:apply-templates select="cylinderPalletAnalysis"/>
        <xsl:apply-templates select="truckAnalysis"/>
        <xsl:apply-templates select="ectAnalysis"/>
      </body>
    </html>
  </xsl:template>
  <xsl:template match="caseAnalysis">
    <h2 style="font-family:arial;color:red;">Umverpackungs Analyse</h2>
    <xsl:apply-templates select="box"/>
    <xsl:apply-templates select="caseWithInnerDims"/>
    <xsl:apply-templates select="caseConstraintSet"/>
    <xsl:apply-templates select="caseSolution"/>
  </xsl:template>
  <xsl:template match="palletAnalysis">
    <h2 style="font-family:arial;color:red;">Paletten Analyse</h2>
    <xsl:apply-templates select="case"/>
    <xsl:apply-templates select="bundle"/>
    <xsl:apply-templates select="box"/>
    <xsl:apply-templates select="caseOfBoxes"/>
    <xsl:apply-templates select="interlayer"/>
    <xsl:apply-templates select="pallet"/>
    <xsl:apply-templates select="constraintSet"/>
    <xsl:apply-templates select="caseOptimConstraintSet"/>
    <xsl:apply-templates select="palletSolution"/>
  </xsl:template>
  <xsl:template match="cylinderAnalysis">
    <h2 style="font-family:arial;color:red;">Cylinder analysis</h2>
    <xsl:apply-templates select="cylinder"/>
    <xsl:apply-templates select="pallet"/>
    <xsl:apply-templates select="interlayer"/>
    <xsl:apply-templates select="cylinderPalletConstraintSet"/>
    <xsl:apply-templates select="cylinderPalletSolution"/>
  </xsl:template>
  <xsl:template match="truckAnalysis">
    <h2 style="font-familly:arial;color:red;">LKW Analyse</h2>
    <xsl:apply-templates select="truck"/>
    <xsl:apply-templates select="truckSolution"/>
  </xsl:template>
  <xsl:template match="ectAnalysis">
    <h2 style="font-familly:arial;color:red;">Box Compression Test analysis</h2>
    <xsl:apply-templates select="cardboard"/>
    <table border="0" cellpadding="2">
      <tr>
        <td class="style2">
          <b>Schachtel Typ</b>
        </td>
        <td class ="style2">
          <b>Gedruckt oberfläche</b>
        </td>
        <td class="style2">
          <b>Mc Kee Formel</b>
        </td>
      </tr>
      <tr>
        <td class="style3">
          <xsl:value-of select="caseType"/>
        </td>
        <td class="style3">
          <xsl:value-of select="printedSurface"/>
        </td>
        <td class="style3">
          <xsl:value-of select="mcKeeFormulaMode"/>
        </td>
      </tr>      
    </table>
    <xsl:apply-templates select="bct_static"/>
    <xsl:apply-templates select="bct_dynamic"/>
  </xsl:template>
  <!-- #### CASE ####-->
  <xsl:template match="case">
    <h3 style="font-family:arial;color:blue;">Kiste</h3>
    <table class="style1" cellpadding="3">
      <tr>
        <td class="style2" colspan="1">
          <b>Name</b>
        </td>
        <td class="style3" colspan="2">
          <xsl:value-of select="name"/>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1">
          <b>Beschreibung</b>
        </td>
        <td class="style3" colspan="2">
          <xsl:value-of select="description"/>
        </td>
      </tr>
      <tr>
        <td  class="style2" colspan="1">
          <b>Länge (mm)</b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="length"/>
        </td>
        <td rowspan="5">
          <xsl:apply-templates select="view_case_iso"/>
        </td>
      </tr>
      <tr>
        <td  class="style2">
          <b>Breite (mm)</b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="width"/>
        </td>
      </tr>
      <tr>
        <td  class="style2">
          <b>Höhe (mm)</b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="height"/>
        </td>
      </tr>
      <tr>
        <td  class="style2">
          <b>Gewicht (kg)</b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="weight"/>
        </td>
      </tr>
      <tr>
        <td  class="style2">
          <b>Erlaubtes Gewicht oben (kg)</b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="admissibleLoad"/>
        </td>
      </tr>
    </table>
  </xsl:template>
  <!--#### CYLINDER ####-->
  <xsl:template match="cylinder">
    <h3 style="font-family:arial;color:blue;">Cylinder</h3>
    <table class="style3" cellpadding="4">
      <tr>
        <td class="style2" colspan="1">
          <b>Name</b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="name"/>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1">
          <b>Description</b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="description"/>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1">
          <b>Radius (mm)</b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="width"/>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1">
          <b>Height (mm)</b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="height"/>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1">
          <b>Weight (kg)</b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="weight"/>
        </td>
        <td colspan="2">
          <xsl:apply-templates select="view_cylinder_iso"/>
        </td>
      </tr>
    </table>
  </xsl:template>  
  <!--#### CASE WITH INNER DIMS #### -->
  <xsl:template match="caseWithInnerDims">
    <h3 style="font-family:arial;color:blue;">Lösung</h3>
    <table class="style3" cellpadding="4">
      <tr>
        <td class="style2" colspan="1">
          <b>Name</b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="name"/>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1">
          <b>Beschreibung</b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="description"/>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1">
          <b>Länge (mm)</b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="length"/>
        </td>
        <td class="style2" colspan="1">
          <b>Länge innen (mm)</b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="innerLength"/>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1">
          <b>Breite (mm)</b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="width"/>
        </td>
        <td class="style2" colspan="1">
          <b>Breite innen (mm)</b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="innerWidth"/>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1">
          <b>Höhe (mm)</b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="height"/>
        </td>
        <td class="style2" colspan="1">
          <b>Höhe innen (mm)</b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="innerHeight"/>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1">
          <b>Gewicht (kg)</b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="weight"/>
        </td>
        <td colspan="2">
          <xsl:apply-templates select="view_case_iso"/>
        </td>
      </tr>
    </table>
  </xsl:template>
  <!-- #### PALLET ####-->
  <xsl:template match="pallet">
    <h3 style="font-family:arial;color:blue;">Palette</h3>
    <table class="style1" cellpadding="3">
      <tr>
        <td  class="style2" colspan="1">
          <b>Name</b>
        </td>
        <td class="style3" colspan="2">
          <xsl:value-of select="name"/>
        </td>
      </tr>
      <tr>
        <td  class="style2" colspan="1">
          <b>Beschreibung</b>
        </td>
        <td class="style3" colspan="2">
          <xsl:value-of select="description"/>
        </td>
      </tr>
      <tr>
        <td  class="style2" colspan="1">
          <b>Länge (mm)</b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="length"/>
        </td>
        <td rowspan="5">
          <xsl:apply-templates select="view_pallet_iso"/>
        </td>
      </tr>
      <tr>
        <td  class="style2" colspan="1">
          <b>Breite (mm)</b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="width"/>
        </td>
      </tr>
      <tr>
        <td  class="style2" colspan="1">
          <b>Höhe (mm)</b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="height"/>
        </td>
      </tr>
      <tr>
        <td  class="style2" colspan="1">
          <b>Gewicht (kg)</b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="weight"/>
        </td>
      </tr>
    </table>
  </xsl:template>
  <!--BOX-->
  <xsl:template match="box">
    <h3 style="font-family:arial;color:blue;">Kiste</h3>
    <table class="style1">
      <tr>
        <td class="style2" colspan="1">
          <b>Name</b>
        </td>
        <td class="style3" colspan="2">
          <xsl:value-of select="name"/>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1">
          <b>Beschreibung</b>
        </td>
        <td class="style3" colspan="2">
          <xsl:value-of select="description"/>
        </td>
      </tr>
      <tr>
        <td  class="style2" colspan="1">
          <b>Länge (mm)</b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="length"/>
        </td>
        <td rowspan="4">
          <xsl:apply-templates select="view_box_iso"/>
        </td>
      </tr>
      <tr>
        <td  class="style2">
          <b>Breite (mm)</b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="width"/>
        </td>
      </tr>
      <tr>
        <td  class="style2">
          <b>Höhe (mm)</b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="height"/>
        </td>
      </tr>
      <tr>
        <td  class="style2">
          <b>Gewicht (kg)</b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="weight"/>
        </td>
      </tr>
    </table>
  </xsl:template>
  <!--#### INTERLAYER ####-->
  <xsl:template match="interlayer">
    <h3 style="font-family:arial;color:blue;">Lagen</h3>
    <table class="style1">
      <tr>
        <td  class="style2">
          <b>Name</b>
        </td>
        <td class="style3" colspan="2">
          <xsl:value-of select="name"/>
        </td>
      </tr>
      <tr>
        <td  class="style2">
          <b>Beschreibung</b>
        </td>
        <td class="style3" colspan="2">
          <xsl:value-of select="description"/>
        </td>
      </tr>
      <tr>
        <td  class="style2">
          <b>Länge (mm)</b>
        </td>
        <td class="style3">
          <xsl:value-of select="length"/>
        </td>
        <td rowspan="4">
          <xsl:apply-templates select="view_interlayer_iso"/>
        </td>
      </tr>
      <tr>
        <td  class="style2">
          <b>Breite (mm)</b>
        </td>
        <td class="style3">
          <xsl:value-of select="width"/>
        </td>
      </tr>
      <tr>
        <td  class="style2">
          <b>Dicke (mm)</b>
        </td>
        <td class="style3">
          <xsl:value-of select="thickness"/>
        </td>
      </tr>
      <tr>
        <td  class="style2">
          <b>Gewicht (kg)</b>
        </td>
        <td class="style3">
          <xsl:value-of select="weight"/>
        </td>
      </tr>
    </table>
  </xsl:template>
  <!--#### BUNDLE ####-->
  <xsl:template match="bundle">
    <h3 style="font-family:arial;color:blue;">Bundle</h3>
    <table class="style1">
      <tr>
        <td  class="style2">
          <b>Name</b>
        </td>
        <td colspan="2">
          <xsl:value-of select="name"/>
        </td>
      </tr>
      <tr>
        <td  class="style2">
          <b>Beschreibung</b>
        </td>
        <td colspan="2">
          <xsl:value-of select="description"/>
        </td>
      </tr>
      <tr>
        <td  class="style2">
          <strong>Länge (mm)</strong>
        </td>
        <td class="style3">
          <xsl:value-of select="length"/>
        </td>
        <td rowspan="6">
          <xsl:apply-templates select="view_bundle_iso"/>
        </td>
      </tr>
      <tr>
        <td  class="style2">
          <b>Breite (mm)</b>
        </td>
        <td class="style3">
          <xsl:value-of select="width"/>
        </td>
      </tr>
      <tr>
        <td  class="style2">
          <b>Anzahl der Ebenen</b>
        </td>
        <td class="style3">
          <xsl:value-of select="numberOfFlats"/>
        </td>
      </tr>
      <tr>
        <td  class="style2">
          <b>Dicke der Einheit (mm)</b>
        </td>
        <td class="style3">
          <xsl:value-of select="unitThickness"/>
        </td>
      </tr>
      <tr>
        <td  class="style2">
          <b>Gewicht der Einheit (kg)</b>
        </td>
        <td class="style3">
          <xsl:value-of select="unitWeight"/>
        </td>
      </tr>
      <tr>
        <td class="style3">
          <b>Gesamt Dicke (mm)</b>
        </td>
        <td class="style3">
          <xsl:value-of select="totalThickness"/>
        </td>
      </tr>
      <tr>
        <td class="style3">
          <b>Gesamt Gewicht (kg)</b>
        </td>
        <td class="style3">
          <xsl:value-of select="totalWeight"/>
        </td>
      </tr>
    </table>
  </xsl:template>
  <!-- #### CASE OF BOXES #### -->
  <xsl:template match="caseOfBoxes">
    <h3 style="font-familly:arial;color:blue;">Lösung der Kiste</h3>
    <table class="style1" cellpadding="4">
      <tr>
        <td class="style2" colspan="1" width="25%">
          <b>Name</b>
        </td>
        <td class="style3" colspan="3" width="75%">
          <xsl:value-of select="name"/>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1" width="25%">
          <b>Beschreibung</b>
        </td>
        <td class="style3" colspan="3" width="75%">
          <xsl:value-of select="description"/>
        </td>
      </tr>
      <tr>
        <td class="style2" width="25%">
          <b>Länge (mm)</b>
        </td>
        <td class="style3" width="25%">
          <xsl:value-of select="outerlength"/>
        </td>
        <td class="style2" width="25%">
          <b>Innenlänge (mm)</b>
        </td>
        <td class="style3" width="25%">
          <xsl:value-of select="innerLength"/>
        </td>
      </tr>
      <tr>
        <td class="style2"  width="25%">
          <b>Breite (mm)</b>
        </td>
        <td class="style3"  width="25%">
          <xsl:value-of select="outerWidth"/>
        </td>
        <td class="style2"  width="25%">
          <b>Innenbreite (mm)</b>
        </td>
        <td class="style3"  width="25%">
          <xsl:value-of select="innerWidth"/>
        </td>
      </tr>
      <tr>
        <td class="style2"  width="25%">
          <b>Höhe (mm)</b>
        </td>
        <td class="style3"  width="25%">
          <xsl:value-of select="outerHeight"/>
        </td>
        <td class="style2"  width="25%">
          <b>Innenhöhe (mm)</b>
        </td>
        <td class="style3"  width="25%">
          <xsl:value-of select="innerHeight"/>
        </td>
      </tr>
      <tr>
        <td class="style2"  width="25%">
          <b>Volumen (l)</b>
        </td>
        <td class="style3"  width="25%">
          <xsl:value-of select="outerVolume"/>
        </td>
        <td class="style2">
          <b>Volumen innen (l)</b>
        </td>
        <td class="style3">
          <xsl:value-of select="innerVolume"/>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>Leegewicht (kg)</b>
        </td>
        <td class="style3">
          <xsl:value-of select="emptyWeight"/>
        </td>
        <td class="style2"  width="25%">
          <b>Gewicht (kg)</b>
        </td>
        <td class="style3"  width="25%">
          <xsl:value-of select="weight"/>
        </td>
      </tr>
      <tr>
        <td class="style2" width="25%">
          <b>Anzahl Schachteln</b>
        </td>
        <td class="style3" width="25%">
          <xsl:value-of select="numberOfBoxes"/>
        </td>
        <td class="style2" width="25%">
          <b>Layout</b>
        </td>
        <td class="style3"  width="25%">
          <xsl:value-of select="noX"/>*<xsl:value-of select="noY"/>*<xsl:value-of select="noZ"/>
        </td>
      </tr>
      <tr>
        <td class="style2" width="25%">
          <b>Mass0</b>
        </td>
        <td class="style3" width="25%">
          <xsl:value-of select="dim0"/>
        </td>
        <td class="style2" width="25%">
          <b>Mass1</b>
        </td>
        <td class="style3" width="25%">
          <xsl:value-of select="dim1"/>
        </td>
      </tr>
      <tr>
        <td colspan="2" width="50%">
          <xsl:apply-templates select="view_caseOfBoxes_iso1"/>
        </td>
        <td colspan="2" width="50%">
          <xsl:apply-templates select="view_caseOfBoxes_iso2"/>
        </td>
      </tr>
    </table>
  </xsl:template>
  <!--#### CONSTRAINT SET ####-->
  <xsl:template match="constraintSet">
    <h3 style="font-family:arial;color:blue;">Bedingungen</h3>
    <table class="style1">
      <tr>
        <td class="style2" width="20%">
          <b>Überstand (mm)</b>
        </td>
        <td class="style2">
          <b>X</b>
        </td>
        <td class="style3">
          <xsl:value-of select="overhangX"/>
        </td>
        <td class="style2">
          <b>Y</b>
        </td>
        <td class="style3">
          <xsl:value-of select="overhangY"/>
        </td>
      </tr>
      <xsl:apply-templates select="maximumPalletWeightGroup">
      </xsl:apply-templates>
      <xsl:apply-templates select="maximumPalletHeightGroup">
      </xsl:apply-templates>
      <xsl:apply-templates select="maximumNumberOfItemsGroup">
      </xsl:apply-templates>
      <xsl:apply-templates select="admissibleLoadOnTopGroup">
      </xsl:apply-templates>
      <tr>
        <td class="style2">
          <b>Erlaubter muster</b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="allowedPatterns"/>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>Erlaubt ortho achsen</b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="allowedOrthoAxis"/>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>Erlaube ausgerichtete Lagen</b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="allowAlignedLayers"/>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>Erlaube alternierende Lagen</b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="allowAlternateLayers"/>
        </td>
      </tr>
      <xsl:apply-templates select="interlayerPeriodGroup">
      </xsl:apply-templates>
    </table>
  </xsl:template>
  <!-- #### CYLINDER PALLET CONSTRAINT SET #### -->
  <xsl:template match="cylinderPalletConstraintSet">
    <h3 style="font-family:arial;color:blue;">Constraint set</h3>
    <table class="style1">
      <tr>
        <td class="style2" width="20%">
          <b>Overhang (mm)</b>
        </td>
        <td class="style2">
          <b>X</b>
        </td>
        <td class="style3">
          <xsl:value-of select="overhangX"/>
        </td>
        <td class="style2">
          <b>Y</b>
        </td>
        <td class="style3">
          <xsl:value-of select="overhangY"/>
        </td>
      </tr>
      <xsl:apply-templates select="maximumPalletWeightGroup">
      </xsl:apply-templates>
      <xsl:apply-templates select="maximumPalletHeightGroup">
      </xsl:apply-templates>
      <xsl:apply-templates select="maximumNumberOfItemsGroup">
      </xsl:apply-templates>
      <xsl:apply-templates select="admissibleLoadOnTopGroup">
      </xsl:apply-templates>
    </table>
  </xsl:template>
  <!--#### CASE OPTIM CONSTRAINT SET ####-->
  <xsl:template match="caseOptimConstraintSet">
    <h3 style="font-familly:arial;color:blue;">Case optimization constraint set</h3>
    <table class="style1" cellpadding="2">
      <tr>
        <td class="style2">
          <b>Wandstärke (mm)</b>
        </td>
        <td class="style3">
          <xsl:value-of select="wallThickness"/>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>Minimale Anzahl Kisten</b>
        </td>
        <td class="style3">
          <xsl:value-of select="caseLimitMin"/>
        </td>
      </tr>
      <tr>
        <td class="style3">
          <b>Maximale Anzahl Kisten</b>
        </td>
        <td class="style3">
          <xsl:value-of select="caseLimitMax"/>
        </td>
      </tr>
    </table>
  </xsl:template>
  <!--#### CASE CONSTRAINTSET ####-->
  <xsl:template match="caseConstraintSet">
    <h3 style="font-family:arial;color:blue;">Lösungs Bedingungen</h3>
    <table class="style1" cellpadding="2">
      <tr>
        <td class="style2">
          <b>Erlaubte Ebenen Muster</b>
        </td>
        <td class="style3">
          <xsl:apply-templates select="allowedPatterns"/>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>Erlaubte Winkel ortogonal</b>
        </td>
        <td class="style3">
          <xsl:apply-templates select="allowedOrthoAxis"/>
        </td>
      </tr>
      <xsl:apply-templates select="maximumCaseWeightGroup"/>
      <xsl:apply-templates select="minimumBoxPerCaseGroup"/>
      <xsl:apply-templates select="maximumBoxPerCaseGroup"/>
    </table>
  </xsl:template>
  <xsl:template match="maximumCaseWeightGroup">
    <tr>
      <td class="style2">
        <b>Maximales Gewicht (kg)</b>
      </td>
      <td class="style3">
        <xsl:value-of select="maximumCaseWeight"/>
      </td>
    </tr>
  </xsl:template>
  <xsl:template match="minimumBoxPerCaseGroup">
    <tr>
      <td class="style2">
        <b>Minimal anzahl</b>
      </td>
      <td class="style3">
        <xsl:value-of select="minimumBoxPerCase"/>
      </td>
    </tr>
  </xsl:template>
  <xsl:template match="maximumBoxPerCaseGroup">
    <tr>
      <td class="style2">
        <b>Maximal anzahl</b>
      </td>
      <td class="style3">
        <xsl:value-of select="maximumBoxPerCase"/>
      </td>
    </tr>
  </xsl:template>
  <!--#### PALLET SOLUTION ####-->
  <xsl:template match="palletSolution">
    <h3 style="font-family:arial;color:blue;">Selected solution</h3>
    <table class="style1">
      <tr>
        <td class="style2">
          <b>Titel</b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="title"/>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>Anzahl Lösungen</b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="caseCount"/>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>Anzahl Zwischenlagen</b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="interlayerCount"/>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>Paletten Gewicht (kg)</b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="palletWeight"/>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>Paletten Höhe (mm)</b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="palletHeight"/>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>Nutzungsgrad (%)</b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="efficiency"/>
        </td>
      </tr>
      <tr>
        <td>
          <xsl:apply-templates select="view_palletsolution_front"/>
        </td>
        <td>
          <xsl:apply-templates select="view_palletsolution_left"/>
        </td>
        <td>
          <xsl:apply-templates select="view_palletsolution_right"/>
        </td>
        <td>
          <xsl:apply-templates select="view_palletsolution_back"/>
        </td>
      </tr>
      <tr>
        <td colspan="4">
          <xsl:apply-templates select="view_palletsolution_iso"/>
        </td>
      </tr>
    </table>
    <h3 style="font-family:arial;color:blue;">Ebene(n)</h3>
    <table class="style1">
      <xsl:apply-templates select="layer"/>
    </table>
  </xsl:template>
  <!-- #### CYLINDER PALLET SOLUTION #### -->
  <xsl:template match="cylinderPaletSolution">
    <h3 style="font-family:arial;color:blue;">Selected solution</h3>
    <table class="style1">
      <tr>
        <td class="style2">
          <b>Title</b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="title"/>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>Number of cylinders</b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="cylinderCount"/>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>Pallet weight (kg)</b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="palletWeight"/>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>Pallet height (mm)</b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="palletHeight"/>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>Efficiency (%)</b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="efficiency"/>
        </td>
      </tr>
      <tr>
        <td>
          <xsl:apply-templates select="view_palletsolution_front"/>
        </td>
        <td>
          <xsl:apply-templates select="view_palletsolution_left"/>
        </td>
        <td>
          <xsl:apply-templates select="view_palletsolution_right"/>
        </td>
        <td>
          <xsl:apply-templates select="view_palletsolution_back"/>
        </td>
      </tr>
      <tr>
        <td colspan="4">
          <xsl:apply-templates select="view_palletsolution_iso"/>
        </td>
      </tr>
    </table>
    <h3 style="font-family:arial;color:blue;">Layer(s)</h3>
    <table class="style1">
      <xsl:apply-templates select="layer"/>
    </table>
  </xsl:template>
  <!--#### CASE SOLUTION ####-->
  <xsl:template match="caseSolution">
    <h3 style="font-family:arial;color:blue;">Lösung</h3>
    <table class="style1" cellpadding="5">
      <tr>
        <td class="style2" colspan="1" width="40%">
          <b>Titel</b>
        </td>
        <td class="style3" colspan="4" width="60%">
          <xsl:value-of select="title"/>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1" width="40%">
          <b>Layer homogeneous</b>
        </td>
        <td class="style3" colspan="4" width="60%">
          <xsl:value-of select="homogeneousLayer"/>
        </td>
      </tr>
      <tr>
        <td class="style3" colspan="1" width="40%"></td>
        <td class="style2" colspan="2" width="30%">
          <b>Umverpackung</b>
        </td>
        <td class="style2" colspan="2" width="30%">
          <b>Palette</b>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1" width="40%">
          <b>Anzahl der Kisten</b>
        </td>
        <td class="style3" colspan="2" width="30%">
          <xsl:value-of select="boxPerCaseCount"/>
        </td>
        <td class="style3" colspan="2" width="30%">
          <xsl:value-of select="boxPerPalletCount"/>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1" width="40%">
          <b>Nutzungsgrad (%)</b>
        </td>
        <td class="style3" colspan="2" width="30%">
          <xsl:value-of select="caseEfficiency"/>
        </td>
        <td class="style3" colspan="2" width="30%">
          <xsl:value-of select="palletEfficiency"/>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1" width="40%">
          <b>Gewicht (kg)</b>
        </td>
        <td class="style3" colspan="2" width="30%">
          <xsl:value-of select="caseWeight"/>
        </td>
        <td class="style3" colspan="2" width="30%">
          <xsl:value-of select="palletWeight"/>
        </td>
      </tr>
      <tr>
        <td colspan="5" width="100%">
          <xsl:apply-templates select="view_caseSolution_iso"/>
        </td>
      </tr>
    </table>
  </xsl:template>
  <!--CASE-->
  <xsl:template match="view_case_iso">
    <img src="images\view_case_iso.gif" width="150" height="150" align="middle"/>
  </xsl:template>
  <!--CYLINDER-->
  <xsl:template match="view_cylinder_iso">
    <img src="images\view_cylinder_iso.gif" width="150" height="150" align="middle"/>
  </xsl:template>
  <!--BOX-->
  <xsl:template match="view_box_iso">
    <img src="images\view_box_iso.gif" width="150" height="150" align="middle"/>
  </xsl:template>
  <!--PALLET-->
  <xsl:template match="view_pallet_iso">
    <img src="images\view_pallet_iso.gif" width="150" height="150" align="middle"/>
  </xsl:template>
  <!--INTERLAYER-->
  <xsl:template match="view_interlayer_iso">
    <img src="images\view_interlayer_iso.gif" width="150" height="150" align="middle"/>
  </xsl:template>
  <!--BUNDLE-->
  <xsl:template match="view_bundle_iso">
    <img src="images\view_interlayer_iso.gif" width="150" height="150" align="middle"/>
  </xsl:template>
  <!--PALLET SOLUTION-->
  <xsl:template match="view_palletsolution_front">
    <img src="images\view_palletsolution_front.gif" width="150" height="150" align="middle"/>
  </xsl:template>
  <xsl:template match="view_palletsolution_left">
    <img src="images\view_palletsolution_left.gif" width="150" height="150" align="middle"/>
  </xsl:template>
  <xsl:template match="view_palletsolution_right">
    <img src="images\view_palletsolution_right.gif" width="150" height="150" align="middle"/>
  </xsl:template>
  <xsl:template match="view_palletsolution_back">
    <img src="images\view_palletsolution_back.gif" width="150" height="150" align="middle"/>
  </xsl:template>
  <xsl:template match="view_palletsolution_iso">
    <img src="images\view_palletsolution_iso.gif" width="450" height="450" align="middle"/>
  </xsl:template>
  <!--CASE OF BOXES-->
  <xsl:template match="view_caseOfBoxes_iso1">
    <img src="images\view_caseOfBoxes_iso1.gif" width="150" height="150" align="middle"/>
  </xsl:template>
  <xsl:template match="view_caseOfBoxes_iso2">
    <img src="images\view_caseOfBoxes_iso2.gif" width="150" height="150" align="middle"/>
  </xsl:template>
  <xsl:template match="view_caseSolution_iso">
    <img src="images\view_caseSolution_iso.gif" width="300" height="300" align="middle"/>
  </xsl:template>
  <xsl:template match="view_truck_iso">
    <img src="images\view_truck_iso.gif" width="150" height="150" align="middle"/>
  </xsl:template>
  <xsl:template match="view_trucksolution_top">
    <img src="images\view_trucksolution_top.gif" width="450" height="450" align="middle"/>
  </xsl:template>
  <xsl:template match="view_trucksolution_iso">
    <img src="images\view_trucksolution_iso.gif" width="450" height="450" align="middle"/>
  </xsl:template>
  <!--STOP STACKING CONDITIONS-->
  <xsl:template match="maximumPalletWeightGroup">
    <tr>
      <td class="style2">
        <b>Maximales Paletten Gewicht (kg)</b>
      </td>
      <td class="style3" colspan="3">
        <xsl:value-of select="maximumPalletWeight"/>
      </td>
    </tr>
  </xsl:template>
  <xsl:template match="maximumPalletHeightGroup">
    <tr>
      <td class="style2">
        <b>Maximale Paletten Höhe (mm)</b>
      </td>
      <td class="style3" colspan="3">
        <xsl:value-of select="maximumPalletHeight"/>
      </td>
    </tr>
  </xsl:template>
  <xsl:template match="maximumNumberOfItemsGroup">
    <tr>
      <td class="style2">
        <b>Maximale Anzahl auf der Palette</b>
      </td>
      <td class="style3" colspan="3">
        <xsl:value-of select="maximumNumberOfItems"/>
      </td>
    </tr>
  </xsl:template>
  <xsl:template match="admissibleLoadOnTopGroup">
    <tr>
      <td class="style2">
        <b>Maximales Gewicht einer Kiste (kg)</b>
      </td>
      <td class="style3" colspan="3">
        <xsl:value-of select="admissibleLoadOnTop"/>
      </td>
    </tr>
  </xsl:template>
  <!--INTERLAYER PERIOD-->
  <xsl:template match="interlayerPeriodGroup">
    <tr>
      <td class="style2">
        <b>Zwischenlage (jede X Ebene)</b>
      </td>
      <td class="style3" colspan="3">
        <xsl:value-of select="interlayerPeriod"/>
      </td>
    </tr>
  </xsl:template>
  <!--LAYER-->
  <xsl:template match="layer">
    <tr>
      <td class="style2">
        <xsl:value-of select="layerId"/>
      </td>
      <td class="style3">
        <xsl:value-of select="layerBoxCount"/>
      </td>
      <td>
        <img src="images\layerImage1.gif" width="150" height="150"/>
      </td>
    </tr>
  </xsl:template>
  <!--TRUCK-->
  <xsl:template match="LKW">
    <table class="style1" cellpadding="3">
      <tr>
        <td class="style2">
          <b>Name</b>
        </td>
        <td class="style3" colspan="2">
          <xsl:value-of select="name"/>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>Beschreibung</b>
        </td>
        <td class="style3" colspan="2">
          <xsl:value-of select="description"/>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>Länge (mm)</b>          
        </td>
        <td class="style3">
          <xsl:value-of select="length"/>
        </td>
        <td rowspan="4">
          <xsl:apply-templates select="view_truck_iso"/>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>Breite (mm)</b>
        </td>
        <td class="style3">
          <xsl:value-of select="width"/>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>Höhe (mm)</b>
        </td>
        <td class="style3">
          <xsl:value-of select="height"/>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>Erlaubte Ladung (kg)</b>
        </td>
        <td class="style3">
          <xsl:value-of select="admissibleLoad"/>
        </td>        
      </tr>
    </table>
  </xsl:template>
  <!--TRUCK SOLUTION-->
  <xsl:template match="truckSolution">
    <h3 style="font-familly:arial;color:blue;">Ausgewählte Lösung</h3>
    <table class="style1" cellpadding="2">
      <tr>
        <td class="style2" width="50%">
          <b>Titel</b>
        </td>
        <td class="style3" width="50%">
          <xsl:value-of select="title"/>
        </td>
      </tr>
      <tr>
        <td class="style2" width="50%">
          <b>Anzahl Paletten:</b>
        </td>
        <td class="style3" width="50%">
          <xsl:value-of select="palletCount"/>
        </td>
      </tr>
      <tr>
        <td class="style2" width="50%">
          <b>Anzahl Lösungen:</b>          
        </td>
        <td class="style3" width="50%">
          <xsl:value-of select="caseCount"/>
        </td>
      </tr>
      <tr>
        <td class="style2" width="50%">
          <b>Ladegewicht (kg):</b>
        </td>
        <td class="style3" width="50%">
          <xsl:value-of select="loadWeight"/>
        </td>        
      </tr>
      <tr>
        <td class="style2" width="50%">
          <b>Nutzungsgrad Gewicht (%):</b>
        </td>
        <td class="style3" width="50%">
          <xsl:value-of select="loadEfficiency"/>
        </td>
      </tr>
      <tr>
        <td class="style2" width="50%">
          <b>Nutzungsgrad Volumen (%):</b>
        </td>
        <td class="style3" width="50%">
          <xsl:value-of select="volumeEfficiency"/>
        </td>
      </tr>
      <tr>
        <td colspan="2">
          <xsl:apply-templates select="view_trucksolution_top"></xsl:apply-templates>
        </td>
      </tr>
      <tr>
        <td colspan="2">
          <xsl:apply-templates select="view_trucksolution_iso"></xsl:apply-templates>
        </td>
      </tr>
    </table>
  </xsl:template>
  <!--CARDBOARD-->
  <xsl:template match="cardboard">
    <h3 style="font-family:arial;color:blue;">Carton</h3>
    <b>Cardboard</b>
    <table border="0" cellpadding="5">
      <tr>
        <td class="style2">
          <b>Name</b>
        </td>
        <td class="style2">
          <b>Dicke (mm)</b>
        </td>
        <td class="style2">
          <b>ECT (N.m)</b>
        </td>
        <td class="style2">
          <b>Biegesteifigkeit X (N/m)</b>
        </td>
        <td class="style2">
          <b>Biegesteifigkeit Y (N/m)</b>
        </td>
      </tr>
      <tr>
        <td class="style3">
          <xsl:value-of select="name"/>
        </td>
        <td>
          <xsl:value-of select="thickness"/>
        </td>
        <td>
          <xsl:value-of select="ect"/>
        </td>
        <td>
          <xsl:value-of select="stiffnessX"/>
        </td>
        <td>
          <xsl:value-of select="stiffnessY"/>
        </td>
      </tr>
    </table>
  </xsl:template>
  <!--BCT_STATIC-->
  <xsl:template match="bct_static">
    <table border="0" cellpadding="2">
      <tr>
        <td class="style2">
          <b>Statischer BCT</b>
        </td>
        <td class="style3">
          <xsl:text/>
        </td>
      </tr>
    </table>
  </xsl:template>
  <!--BCT_DYNAMIC-->
  <xsl:template match="bct_dynamic">
    <b>Dynamischer BCT</b>
    <table border="0" cellpadding="7">
      <tr>
        <td class="style2">
          <b>Lager</b>
        </td>
        <td class="style2">
          <b>0-45 %</b>
        </td>
        <td class="style2">
          <b>46-55 %</b>
        </td>
        <td class="style2">
          <b>56-65 %</b>
        </td>
        <td class="style2">
          <b>66-75 %</b>
        </td>
        <td class="style2">
          <b>76-85 %</b>
        </td>
        <td class="style2">
          <b>86-100 %</b>
        </td>
      </tr>
      <xsl:apply-templates select="bct_dynamic_storage"/>
    </table>
  </xsl:template>
  <!--BCT_DYNAMIC_STORAGE-->
  <xsl:template match="bct_dynamic_storage">
    <tr>
      <td class="style2">
        <b>
          <xsl:value-of select="duration"/>
        </b>
      </td>
      <xsl:apply-templates select="humidity_0_45"/>
      <xsl:apply-templates select="humidity_46_55"/>
      <xsl:apply-templates select="humidity_56_65"/>
      <xsl:apply-templates select="humidity_66_75"/>
      <xsl:apply-templates select="humidity_76_85"/>
      <xsl:apply-templates select="humidity_86_100"/>
    </tr>
  </xsl:template>
  <!--humidity_0_45-->
  <xsl:template match="humidity_0_45">
    <xsl:choose>
      <xsl:when test="@admissible='true'">
        <td class="style3">
          <xsl:value-of select="."/>
        </td>
      </xsl:when>
      <xsl:otherwise>
        <td class="style4">
          <xsl:value-of select="."/>
        </td>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>
  <!--humidity_46_55-->
  <xsl:template match="humidity_46_55">
    <xsl:choose>
      <xsl:when test="@admissible='true'">
        <td class="style3">
          <xsl:value-of select="."/>
        </td>
      </xsl:when>
      <xsl:otherwise>
        <td class="style4">
          <xsl:value-of select="."/>
        </td>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>
  <!--humidity_56_65-->
  <xsl:template match="humidity_56_65">
    <xsl:choose>
      <xsl:when test="@admissible='true'">
        <td class="style3">
          <xsl:value-of select="."/>
        </td>
      </xsl:when>
      <xsl:otherwise>
        <td class="style4">
          <xsl:value-of select="."/>
        </td>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>
  <!--humidity_66_75-->
  <xsl:template match="humidity_66_75">
    <xsl:choose>
      <xsl:when test="@admissible='true'">
        <td class="style3">
          <xsl:value-of select="."/>
        </td>
      </xsl:when>
      <xsl:otherwise>
        <td class="style4">
          <xsl:value-of select="."/>
        </td>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>
  <!--humidity_76_85-->
  <xsl:template match="humidity_76_85">
    <xsl:choose>
      <xsl:when test="@admissible='true'">
        <td class="style3">
          <xsl:value-of select="."/>
        </td>
      </xsl:when>
      <xsl:otherwise>
        <td class="style4">
          <xsl:value-of select="."/>
        </td>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>
  <!--humidity_76_85-->
  <xsl:template match="humidity_86_100">
    <xsl:choose>
      <xsl:when test="@admissible='true'">
        <td class="style3">
          <xsl:value-of select="."/>
        </td>
      </xsl:when>
      <xsl:otherwise>
        <td class="style4">
          <xsl:value-of select="."/>
        </td>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>
</xsl:stylesheet>