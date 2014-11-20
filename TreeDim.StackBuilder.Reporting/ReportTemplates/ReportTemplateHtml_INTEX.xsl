<?xml version="1.0" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
	xsi:noNamespaceSchemaLocation=".\ReportSchema.xsd">
  <xsl:output method="html" indent="yes"/>
  <xsl:template match="report">
    <html>
      <head>
        <title>
          Rapport : <xsl:value-of select="name"/>
        </title>
        <style type="text/css">
          .style1
          {
          width:200mm;
          color:blue;
          }
          .style2
          {
          width: 50mm;
          color:black;
          font-family:Arial;
          font-size:10px;
          }
          .style3
          {
          color:black;
          font-family:Arial;
          font-size:10px;
          }
          body
          {
          font-family:Arial;
          font-size:11px;
          margin: 5%;
          width: 90%;
          padding: 0;
          }
          h1
          {
          color:black;
          font-size:20px;
          font-family:Arial;
          width:200mm
          }
          h2
          {
          color:red;
          font-size:16px;
          font-family:Arial;
          }
          h3
          {
          color:blue;
          font-size:12px;
          font-family:Arial;
          }
          table
          {
          border:solid grey 1px;
          width:200mm;
          border-spacing: 0px;
          cell-spacing: 0px;
          }
          td
          {
          padding: 0px;
          }
        </style>
      </head>
      <body>
        <table class="style1" cellpadding="4">
          <xsl:if test="companyLogo">
            <tr>
              <td class="style2" colspan="1"/>
              <td class="style3" colspan="1"/>
              <td class="style2" colspan="1"/>
              <td colspan="1" align="middle">
                <xsl:apply-templates select="companyLogo"/>
              </td>
            </tr>
          </xsl:if>
          <tr>
            <td colspan="4">
              <h1 style="text-align:center">
                <b>
                  Produit <xsl:value-of select="name"/>
                </b>
              </h1>
            </td>
          </tr>
          <tr>
            <td class="style2" colspan="1">
              <xsl:value-of select="dateOfCreation"/>
            </td>
            <td class="style3" colspan="3">
            </td>
          </tr>
        </table>
        <xsl:apply-templates select="boxCaseAnalysis"/>
        <xsl:apply-templates select="casePalletAnalysis"/>
        <xsl:apply-templates select="cylinderPalletAnalysis"/>
        <xsl:apply-templates select="hCylinderPalletAnalysis"/>
        <xsl:apply-templates select="truckAnalysis"/>
        <xsl:apply-templates select="ectAnalysis"/>
      </body>
    </html>
  </xsl:template>

  <!-- Splitting templates : templates -->
  <xsl:template match="description">
    <xsl:call-template name="print-lines"/>
  </xsl:template>

  <xsl:template name="print-lines">
    <!-- If we are not passed text as a param, use the node's text. -->
    <xsl:param name="text" select="text()"/>

    <!-- If there is no (more) text, we are finished. -->
    <xsl:if test="string-length(normalize-space($text)) > 0">
      <xsl:choose>
        <!-- If the text contains a newline... -->
        <xsl:when test="contains($text, ';')">
          <!-- Split text into the first line and the remainder.  We search
                for the newline char using the '&#10;' entity instead of '\n'. -->
          <xsl:variable name="line" select="substring-before($text, ';')"/>
          <xsl:variable name="remainder" select="substring-after($text, ';')"/>

          <!-- Output the line, a HTML <br/> tag and a newline. -->
          <xsl:value-of select="normalize-space($line)"/>
          <xsl:element name="br"/>
          <xsl:text>&#10;</xsl:text>

          <!-- Recurse using the remaining text. -->
          <xsl:call-template name="print-lines">
            <xsl:with-param name="text" select="$remainder"/>
          </xsl:call-template>
        </xsl:when>
        <!-- Otherwise no more newlines, output the remaining text. -->
        <xsl:otherwise>
          <xsl:value-of select="normalize-space($text)"/>
        </xsl:otherwise>
      </xsl:choose>
    </xsl:if>
  </xsl:template>
  <!-- Splitting templates : templates -->

  <xsl:template match="boxCaseAnalysis">
    <h2>Analyse Etui/Caisse</h2>
    <xsl:apply-templates select="box"/>
    <xsl:apply-templates select="caseWithInnerDims"/>
    <xsl:apply-templates select="boxCaseSolution"/>
  </xsl:template>
  <xsl:template match="casePalletAnalysis">
    <h2>Analyse Caisse/Palette</h2>
    <xsl:apply-templates select="case"/>
    <xsl:apply-templates select="bundle"/>
    <xsl:apply-templates select="box"/>
    <xsl:apply-templates select="caseOfBoxes"/>
    <xsl:apply-templates select="interlayer"/>
    <xsl:apply-templates select="pallet"/>
    <xsl:apply-templates select="palletSolution"/>
  </xsl:template>
  <xsl:template match="cylinderAnalysis">
    <h2>Analyse Cylindre/Palette</h2>
    <xsl:apply-templates select="cylinder"/>
    <xsl:apply-templates select="pallet"/>
    <xsl:apply-templates select="interlayer"/>
    <xsl:apply-templates select="cylinderPalletConstraintSet"/>
    <xsl:apply-templates select="cylinderPalletSolution"/>
  </xsl:template>
  <xsl:template match="truckAnalysis">
    <h2>Analyse camion</h2>
    <xsl:apply-templates select="truck"/>
    <xsl:apply-templates select="truckSolution"/>
  </xsl:template>
  <!-- #### CASE ####-->
  <xsl:template match="case">
    <h3>Caisse</h3>
    <table class="style1" cellpadding="3">
      <tr>
        <td class="style2" colspan="1">
          <b>Nom</b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="name"/>
        </td>
        <td rowspan="6" align="middle" colspan="1">
          <xsl:apply-templates select="view_case_iso"/>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1">
          <b>Description</b>
        </td>
        <td class="style3" colspan="1">
          <xsl:apply-templates select="description"/>
        </td>
      </tr>
      <tr>
        <td  class="style2" colspan="1">
          <b>
            Longueur (<xsl:value-of select="length/unit"/>)
          </b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="length/value"/>
        </td>
      </tr>
      <tr>
        <td  class="style2" colspan="1">
          <b>
            Largeur (<xsl:value-of select="width/unit"/>)
          </b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="width/value"/>
        </td>
      </tr>
      <tr>
        <td  class="style2" colspan="1">
          <b>
            Hauteur (<xsl:value-of select="height/unit"/>)
          </b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="height/value"/>
        </td>
      </tr>
      <tr>
        <td  class="style2" colspan="1">
          <b>
            Masse brute (<xsl:value-of select="weight/unit"/>)
          </b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="weight/value"/>
        </td>
      </tr>
      <xsl:if test="admissibleLoad">
        <tr>
          <td  class="style2" colspan="1">
            <b>
              Admissible load on top (<xsl:value-of select="admissibleLoad/unit"/>)
            </b>
          </td>
          <td class="style3" colspan="1">
            <xsl:value-of select="admissibleLoad/value"/>
          </td>
        </tr>
      </xsl:if>
    </table>
  </xsl:template>
  <!--#### CYLINDER ####-->
  <xsl:template match="cylinder">
    <h3>Cylinder</h3>
    <table class="style1" cellpadding="4">
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
          <b>
            Radius (<xsl:value-of select="radius/unit"/>)
          </b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="radius/value"/>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1">
          <b>
            Hauteur (<xsl:value-of select="height/unit"/>)
          </b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="height/value"/>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1">
          <b>
            Masse (<xsl:value-of select="weight/unit"/>)
          </b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="weight/value"/>
        </td>
        <td colspan="2" align="middle">
          <xsl:apply-templates select="view_cylinder_iso"/>
        </td>
      </tr>
    </table>
  </xsl:template>
  <!--#### CASE WITH INNER DIMS #### -->
  <xsl:template match="caseWithInnerDims">
    <h3>Caisse</h3>
    <table class="style1" cellpadding="3">
      <tr>
        <td class="style2" colspan="1">
          <b>Nom</b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="name"/>
        </td>
        <td colspan="1" align="middle" rowspan="3">
          <xsl:apply-templates select="view_case_iso"/>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1">
          <b>
            Dimensions(<xsl:value-of select="length/unit"/>)
          </b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="length/value"/> * <xsl:value-of select="width/value"/> * <xsl:value-of select="height/value"/>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1">
          <b>
            Masse (<xsl:value-of select="weight/unit"/>)
          </b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="weight/value"/>
        </td>
      </tr>

    </table>
  </xsl:template>
  <!-- #### PALLET ####-->
  <xsl:template match="pallet">
    <h3>Palette</h3>
    <table class="style1" cellpadding="2">
      <tr>
        <td  class="style2" colspan="1">
          <b>Nom</b>
        </td>
        <td class="style3" colspan="1">
          <b>
            <xsl:value-of select="name"/>
          </b>
        </td>
      </tr>
    </table>
  </xsl:template>
  <!--BOX-->
  <xsl:template match="box">
    <h3>Etui</h3>
    <table class="style1">
      <tr>
        <td class="style2" colspan="1">
          <b>Nom</b>
        </td>
        <td class="style3" colspan="2">
          <xsl:value-of select="name"/>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1">
          <b>Description</b>
        </td>
        <td class="style3" colspan="2">
          <xsl:apply-templates select="description"/>
        </td>
      </tr>
      <tr>
        <td  class="style2" colspan="1">
          <b>
            Longueur (<xsl:value-of select="length/unit"/>)
          </b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="length/value"/>
        </td>
        <td rowspan="4" align="middle">
          <xsl:apply-templates select="view_box_iso"/>
        </td>
      </tr>
      <tr>
        <td  class="style2">
          <b>
            Largeur (<xsl:value-of select="width/unit"/>)
          </b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="width/value"/>
        </td>
      </tr>
      <tr>
        <td  class="style2">
          <b>
            Hauteur (<xsl:value-of select="height/unit"/>)
          </b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="height/value"/>
        </td>
      </tr>
      <tr>
        <td  class="style2">
          <b>
            Masse (<xsl:value-of select="weight/unit"/>)
          </b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="weight/value"/>
        </td>
      </tr>
    </table>
  </xsl:template>
  <!--#### INTERLAYER ####-->
  <xsl:template match="interlayer">
    <h3>Intercallaire</h3>
    <table class="style1">
      <tr>
        <td  class="style2">
          <b>Nom</b>
        </td>
        <td class="style3" colspan="2">
          <xsl:value-of select="name"/>
        </td>
      </tr>
      <tr>
        <td  class="style2">
          <b>Description</b>
        </td>
        <td class="style3" colspan="2">
          <xsl:value-of select="description"/>
        </td>
      </tr>
      <tr>
        <td  class="style2">
          <b>
            Longueur (<xsl:value-of select="length/unit"/>)
          </b>
        </td>
        <td class="style3">
          <xsl:value-of select="length/value"/>
        </td>
        <td rowspan="4" align="middle">
          <xsl:apply-templates select="view_interlayer_iso"/>
        </td>
      </tr>
      <tr>
        <td  class="style2">
          <b>
            Largeur (<xsl:value-of select="width/unit"/>)
          </b>
        </td>
        <td class="style3">
          <xsl:value-of select="width/value"/>
        </td>
      </tr>
      <tr>
        <td  class="style2">
          <b>
            Thickness (<xsl:value-of select="thickness/unit"/>)
          </b>
        </td>
        <td class="style3">
          <xsl:value-of select="thickness/value"/>
        </td>
      </tr>
      <tr>
        <td  class="style2">
          <b>
            Masse (<xsl:value-of select="weight/unit"/>)
          </b>
        </td>
        <td class="style3">
          <xsl:value-of select="weight/value"/>
        </td>
      </tr>
    </table>
  </xsl:template>
  <!--#### BUNDLE ####-->
  <xsl:template match="bundle">
    <h3>Liasse</h3>
    <table class="style1">
      <tr>
        <td  class="style2">
          <b>Nom</b>
        </td>
        <td colspan="2">
          <xsl:value-of select="name"/>
        </td>
      </tr>
      <tr>
        <td  class="style2">
          <b>Description</b>
        </td>
        <td colspan="2">
          <xsl:value-of select="description"/>
        </td>
      </tr>
      <tr>
        <td  class="style2">
          <strong>
            Longueur (<xsl:value-of select="length/unit"/>)
          </strong>
        </td>
        <td class="style3">
          <xsl:value-of select="length/value"/>
        </td>
        <td rowspan="6" align="middle">
          <xsl:apply-templates select="view_bundle_iso"/>
        </td>
      </tr>
      <tr>
        <td  class="style2">
          <b>
            Largeur (<xsl:value-of select="width/unit"/>)
          </b>
        </td>
        <td class="style3">
          <xsl:value-of select="width/value"/>
        </td>
      </tr>
      <tr>
        <td  class="style2">
          <b>Nombre de plats</b>
        </td>
        <td class="style3">
          <xsl:value-of select="numberOfFlats"/>
        </td>
      </tr>
      <tr>
        <td  class="style2">
          <b>
            Epaisseur unitaire (<xsl:value-of select="unitThickness/unit"/>)
          </b>
        </td>
        <td class="style3">
          <xsl:value-of select="unitThickness/value"/>
        </td>
      </tr>
      <tr>
        <td  class="style2">
          <b>
            Masse unitaire (<xsl:value-of select="unitWeight/unit"/>)
          </b>
        </td>
        <td class="style3">
          <xsl:value-of select="unitWeight/value"/>
        </td>
      </tr>
      <tr>
        <td class="style3">
          <b>
            Epaisseur totale (<xsl:value-of select="totalThickness/unit"/>)
          </b>
        </td>
        <td class="style3">
          <xsl:value-of select="totalThickness/value"/>
        </td>
      </tr>
      <tr>
        <td class="style3">
          <b>
            Masse totale (<xsl:value-of select="totalWeight/unit"/>)
          </b>
        </td>
        <td class="style3">
          <xsl:value-of select="totalWeight/value"/>
        </td>
      </tr>
    </table>
  </xsl:template>
  <!-- #### CASE OF BOXES #### -->
  <xsl:template match="caseOfBoxes">
    <h3>Casse d'étuis</h3>
    <table class="style1" cellpadding="4">
      <tr>
        <td class="style2" colspan="1" width="25%">
          <b>Nom</b>
        </td>
        <td class="style3" colspan="3" width="75%">
          <xsl:value-of select="name"/>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1" width="25%">
          <b>Description</b>
        </td>
        <td class="style3" colspan="3" width="75%">
          <xsl:value-of select="description"/>
        </td>
      </tr>
      <tr>
        <td class="style2" width="25%">
          <b>
            Longueur (<xsl:value-of select="outerlength/unit"/>)
          </b>
        </td>
        <td class="style3" width="25%">
          <xsl:value-of select="outerlength/value"/>
        </td>
        <td class="style2" width="25%">
          <b>
            Longeur intérieure (<xsl:value-of select="innerlength/unit"/>)
          </b>
        </td>
        <td class="style3" width="25%">
          <xsl:value-of select="innerLength/value"/>
        </td>
      </tr>
      <tr>
        <td class="style2"  width="25%">
          <b>
            Largeur (<xsl:value-of select="outerWidth/unit"/>)
          </b>
        </td>
        <td class="style3"  width="25%">
          <xsl:value-of select="outerWidth/value"/>
        </td>
        <td class="style2"  width="25%">
          <b>
            Largeur intérieure (<xsl:value-of select="outerWidth/unit"/>)
          </b>
        </td>
        <td class="style3"  width="25%">
          <xsl:value-of select="innerWidth/value"/>
        </td>
      </tr>
      <tr>
        <td class="style2"  width="25%">
          <b>
            Hauteur (<xsl:value-of select="outerHeight/unit"/>)
          </b>
        </td>
        <td class="style3"  width="25%">
          <xsl:value-of select="outerHeight/value"/>
        </td>
        <td class="style2"  width="25%">
          <b>
            Hauteur intérieure (<xsl:value-of select="innerHeight/unit"/>)
          </b>
        </td>
        <td class="style3"  width="25%">
          <xsl:value-of select="innerHeight/value"/>
        </td>
      </tr>
      <tr>
        <td class="style2"  width="25%">
          <b>
            Volume (<xsl:value-of select="outerVolume/unit"/>)
          </b>
        </td>
        <td class="style3"  width="25%">
          <xsl:value-of select="outerVolume/value"/>
        </td>
        <td class="style2">
          <b>
            Volume interne (<xsl:value-of select="innerVolume/unit"/>)
          </b>
        </td>
        <td class="style3">
          <xsl:value-of select="innerVolume/value"/>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>
            Masse (vide) (<xsl:value-of select="emptyWeight/unit"/>)
          </b>
        </td>
        <td class="style3">
          <xsl:value-of select="emptyWeight/value"/>
        </td>
        <td class="style2"  width="25%">
          <b>
            Masse (<xsl:value-of select="weight/unit"/>)
          </b>
        </td>
        <td class="style3"  width="25%">
          <xsl:value-of select="weight/value"/>
        </td>
      </tr>
      <tr>
        <td class="style2" width="25%">
          <b>Nombre d'étuis</b>
        </td>
        <td class="style3" width="25%">
          <xsl:value-of select="numberOfBoxes"/>
        </td>
        <td class="style2" width="25%">
          <b>Disposition</b>
        </td>
        <td class="style3"  width="25%">
          <xsl:value-of select="noX"/>*<xsl:value-of select="noY"/>*<xsl:value-of select="noZ"/>
        </td>
      </tr>
      <tr>
        <td class="style2" width="25%">
          <b>Dim0</b>
        </td>
        <td class="style3" width="25%">
          <xsl:value-of select="dim0"/>
        </td>
        <td class="style2" width="25%">
          <b>Dim1</b>
        </td>
        <td class="style3" width="25%">
          <xsl:value-of select="dim1"/>
        </td>
      </tr>
      <tr>
        <td colspan="2" align="middle">
          <xsl:apply-templates select="view_caseOfBoxes_iso1"/>
        </td>
        <td colspan="2" align="middle">
          <xsl:apply-templates select="view_caseOfBoxes_iso2"/>
        </td>
      </tr>
    </table>
  </xsl:template>
  <!--#### CONSTRAINT SET ####-->
  <xsl:template match="constraintSet">
    <h3>Jeu de contraintes</h3>
    <table class="style1">
      <tr>
        <td class="style2">
          <b>
            Débord Longueur/Largeur(<xsl:value-of select="overhangX/unit"/>)
          </b>
        </td>
        <td class="style3">
          <xsl:value-of select="overhangX/value"/> / <xsl:value-of select="overhangY/value"/>
        </td>
      </tr>
      <xsl:if test="maximumPalletWeightGroup">
        <xsl:apply-templates select="maximumPalletWeightGroup">
        </xsl:apply-templates>
      </xsl:if>
      <xsl:apply-templates select="maximumPalletHeightGroup">
      </xsl:apply-templates>
      <xsl:apply-templates select="maximumNumberOfItemsGroup">
      </xsl:apply-templates>
      <xsl:apply-templates select="admissibleLoadOnTopGroup">
      </xsl:apply-templates>
      <tr>
        <td class="style2">
          <b>Orientations permises</b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="allowedOrthoAxis"/>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>Couches alignées autorisé</b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="allowAlignedLayers"/>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>Couches alternées autorisé</b>
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
    <h3>Constraint set</h3>
    <table class="style1" cellpadding="2">
      <tr>
        <td class="style2" width="20%">
          <b>
            Débord Longueur/Largeur(<xsl:value-of select="overhangX/unit"/>)
          </b>
        </td>
        <td class="style3">
          <xsl:value-of select="overhangX/value"/> / <xsl:value-of select="overhangY/value"/>
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
    <h3>Jeu de containte optimisation de caisse</h3>
    <table class="style1" cellpadding="2">
      <tr>
        <td class="style2">
          <b>
            Epaisseur mur (<xsl:value-of select="wallThickness/unit"/>)
          </b>
        </td>
        <td class="style3">
          <xsl:value-of select="wallThickness/value"/>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>
            Masse surfacique (<xsl:value-of select="wallMassSurface/unit"/>)
          </b>
        </td>
        <td class="style3">
          <xsl:value-of select="wallMassSurface/value"/>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>Dimensions minimales</b>
        </td>
        <td class="style3">
          <xsl:value-of select="caseLimitMin"/>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>Dimensions maximales</b>
        </td>
        <td class="style3">
          <xsl:value-of select="caseLimitMax"/>
        </td>
      </tr>
    </table>
  </xsl:template>
  <xsl:template match="maximumCaseWeightGroup">
    <tr>
      <td class="style2">
        <b>
          Masse caisse maximale (<xsl:value-of select="maximumCaseWeight/unit"/>)
        </b>
      </td>
      <td class="style3">
        <xsl:value-of select="maximumCaseWeight/value"/>
      </td>
    </tr>
  </xsl:template>
  <xsl:template match="minimumBoxPerCaseGroup">
    <tr>
      <td class="style2">
        <b>
          Nombre minimum d'étui
        </b>
      </td>
      <td class="style3">
        <xsl:value-of select="minimumBoxPerCase"/>
      </td>
    </tr>
  </xsl:template>
  <xsl:template match="maximumBoxPerCaseGroup">
    <tr>
      <td class="style2">
        <b>Nombre maximal d'étui</b>
      </td>
      <td class="style3">
        <xsl:value-of select="maximumBoxPerCase"/>
      </td>
    </tr>
  </xsl:template>
  <!--#### PALLET SOLUTION ####-->
  <xsl:template match="palletSolution">
    <table class="style1">
      <tr>
        <td class="style2">
          <b>Nombre de caisses / palette</b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="caseCount"/>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>Nombre de caisses / couche</b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="layer1_caseCount"/>
          <xsl:if test="layer2_caseCount">
            / <xsl:value-of select="layer2_caseCount"/>
          </xsl:if>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>Nombre de couches / palette</b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="layerCount"/>
        </td>
      </tr>
      <xsl:if test="interlayerCount">
        <tr>
          <td class="style2">
            <b>Nombre d'intercallaires</b>
          </td>
          <td class="style3" colspan="3">
            <xsl:value-of select="interlayerCount"/>
          </td>
        </tr>
      </xsl:if>
      <tr>
        <td class="style2">
          <b>
            Masse brute palette (<xsl:value-of select="palletWeight/unit"/>)
          </b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="palletWeight/value"/>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>
            Longueur / Largeur / Hauteur (<xsl:value-of select="palletHeight/unit"/>)
          </b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="palletLength/value"/> / <xsl:value-of select="palletWidth/value"/> / <xsl:value-of select="palletHeight/value"/>
        </td>
      </tr>
      <tr>
        <td colspan="4" align="middle">
          <xsl:apply-templates select="view_palletsolution_iso"/>
        </td>
      </tr>
    </table>
  </xsl:template>
  <!-- #### CYLINDER PALLET SOLUTION #### -->
  <xsl:template match="cylinderPaletSolution">
    <h3>Solution sélectionnée</h3>
    <table class="style1">
      <tr>
        <td class="style2">
          <b>Titre</b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="title"/>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>Nombre de cylindres</b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="cylinderCount"/>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>
            Masse palette (<xsl:value-of select="palletWeight/unit"/>)
          </b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="palletWeight/value"/>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>
            Hauteur palette (<xsl:value-of select="palletHeight/unit"/>)
          </b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="palletHeight/value"/>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>Efficacité (%)</b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="efficiency"/>
        </td>
      </tr>
      <tr>
        <td align="middle">
          <xsl:apply-templates select="view_palletsolution_front"/>
        </td>
        <td align="middle">
          <xsl:apply-templates select="view_palletsolution_left"/>
        </td>
        <td align="middle">
          <xsl:apply-templates select="view_palletsolution_right"/>
        </td>
        <td align="middle">
          <xsl:apply-templates select="view_palletsolution_back"/>
        </td>
      </tr>
      <tr>
        <td colspan="4" align="middle">
          <xsl:apply-templates select="view_palletsolution_iso"/>
        </td>
      </tr>
    </table>
    <h3>Couche(s)</h3>
    <table class="style1">
      <xsl:apply-templates select="layer"/>
    </table>
  </xsl:template>
  <!--#### CASE SOLUTION ####-->
  <xsl:template match="boxCaseSolution">
    <table class="style1" cellpadding="3">
      <tr>
        <td class="style2" colspan="1">
          <b>Nombre d'étuis/caisse</b>
        </td>
        <td class="style3" colspan="2">
          <xsl:value-of select="boxPerCaseCount"/>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1">
          <b>
            Masse brute (<xsl:value-of select="CaseWeight/unit"/>)
          </b>
        </td>
        <td class="style3" colspan="2">
          <xsl:value-of select="CaseWeight/value"/>
        </td>
      </tr>
      <tr>
        <td colspan="3" align="middle">
          <xsl:apply-templates select="view_caseSolution_iso"/>
        </td>
      </tr>
    </table>
  </xsl:template>
  <!--COMPANYLOGO-->
  <xsl:template match="companyLogo">
    <img src="images\companyLogo.png" width="162" height="50" align="middle"/>
  </xsl:template>
  <!--CASE-->
  <xsl:template match="view_case_iso">
    <img src="images\view_case_iso.png" width="200" height="200" align="middle"/>
  </xsl:template>
  <!--CYLINDER-->
  <xsl:template match="view_cylinder_iso">
    <img src="images\view_cylinder_iso.png" width="200" height="200" align="middle"/>
  </xsl:template>
  <!--BOX-->
  <xsl:template match="view_box_iso">
    <img src="images\view_box_iso.png" width="200" height="200" align="middle"/>
  </xsl:template>
  <!--PALLET-->
  <xsl:template match="view_pallet_iso">
    <img src="images\view_pallet_iso.png" width="200" height="200" align="middle"/>
  </xsl:template>
  <!--INTERLAYER-->
  <xsl:template match="view_interlayer_iso">
    <img src="images\view_interlayer_iso.png" width="200" height="200" align="middle"/>
  </xsl:template>
  <!--BUNDLE-->
  <xsl:template match="view_bundle_iso">
    <img src="images\view_interlayer_iso.png" width="200" height="200" align="middle"/>
  </xsl:template>
  <!--PALLET SOLUTION-->
  <xsl:template match="view_palletsolution_front">
    <img src="images\view_palletsolution_front.png" width="200" height="200" align="middle"/>
  </xsl:template>
  <xsl:template match="view_palletsolution_left">
    <img src="images\view_palletsolution_left.png" width="200" height="200" align="middle"/>
  </xsl:template>
  <xsl:template match="view_palletsolution_right">
    <img src="images\view_palletsolution_right.png" width="200" height="200" align="middle"/>
  </xsl:template>
  <xsl:template match="view_palletsolution_back">
    <img src="images\view_palletsolution_back.png" width="200" height="200" align="middle"/>
  </xsl:template>
  <xsl:template match="view_palletsolution_iso">
    <img src="images\view_palletsolution_iso.png" width="500" height="500" align="middle"/>
  </xsl:template>
  <!--CASE OF BOXES-->
  <xsl:template match="view_caseOfBoxes_iso1">
    <img src="images\view_caseOfBoxes_iso1.png" width="200" height="200" align="middle"/>
  </xsl:template>
  <xsl:template match="view_caseOfBoxes_iso2">
    <img src="images\view_caseOfBoxes_iso2.png" width="200" height="200" align="middle"/>
  </xsl:template>
  <xsl:template match="view_caseSolution_iso">
    <img src="images\view_caseSolution_iso.png" width="500" height="500" align="middle"/>
  </xsl:template>
  <xsl:template match="view_truck_iso">
    <img src="images\view_truck_iso.png" width="150" height="200" align="middle"/>
  </xsl:template>
  <xsl:template match="view_trucksolution_top">
    <img src="images\view_trucksolution_top.png" width="500" height="500" align="middle"/>
  </xsl:template>
  <xsl:template match="view_trucksolution_iso">
    <img src="images\view_trucksolution_iso.png" width="500" height="500" align="middle"/>
  </xsl:template>
  <!--STOP STACKING CONDITIONS-->
  <xsl:template match="maximumPalletWeightGroup">
    <xsl:if test="maximumPalletWeight">
      <tr>
        <td class="style2">
          <b>
            Masse palette maximale (<xsl:value-of select="maximumPalletWeight/unit"/>)
          </b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="maximumPalletWeight/value"/>
        </td>
      </tr>
    </xsl:if>
  </xsl:template>
  <xsl:template match="maximumPalletHeightGroup">
    <tr>
      <td class="style2">
        <b>
          Hauteur palette maximale (<xsl:value-of select="maximumPalletHeight/unit"/>)
        </b>
      </td>
      <td class="style3" colspan="3">
        <xsl:value-of select="maximumPalletHeight/value"/>
      </td>
    </tr>
  </xsl:template>
  <xsl:template match="maximumNumberOfItemsGroup">
    <tr>
      <td class="style2">
        <b>Nombre maximal de caisses</b>
      </td>
      <td class="style3" colspan="3">
        <xsl:value-of select="maximumNumberOfItems"/>
      </td>
    </tr>
  </xsl:template>
  <xsl:template match="admissibleLoadOnTopGroup">
    <tr>
      <td class="style2">
        <b>
          Chargement maximal sur caisse (<xsl:value-of select="admissibleLoadOnTop/unit"/>)
        </b>
      </td>
      <td class="style3" colspan="3">
        <xsl:value-of select="admissibleLoadOnTop/value"/>
      </td>
    </tr>
  </xsl:template>
  <!--INTERLAYER PERIOD-->
  <xsl:template match="interlayerPeriodGroup">
    <tr>
      <td class="style2">
        <b>Période intercallaire</b>
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
        <xsl:value-of select="layerCaseCount"/>
      </td>
      <td align="middle">
        <xsl:if test="layerId='1'">
          <img src="images\layerImage1.png" width="200" height="200"/>
        </xsl:if>
        <xsl:if test="layerId='2'">
          <img src="images\layerImage2.png" width="200" height="200"/>
        </xsl:if>
      </td>
    </tr>
  </xsl:template>
  <!--TRUCK-->
  <xsl:template match="truck">
    <table class="style1" cellpadding="3">
      <tr>
        <td class="style2">
          <b>Nom</b>
        </td>
        <td class="style3" colspan="2">
          <xsl:value-of select="name"/>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>Description</b>
        </td>
        <td class="style3" colspan="2">
          <xsl:value-of select="description"/>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>
            Longueur (<xsl:value-of select="length/unit"/>)
          </b>
        </td>
        <td class="style3">
          <xsl:value-of select="length/value"/>
        </td>
        <td rowspan="4" align="middle">
          <xsl:apply-templates select="view_truck_iso"/>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>
            Largeur (<xsl:value-of select="width/unit"/>)
          </b>
        </td>
        <td class="style3">
          <xsl:value-of select="width/value"/>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>
            Hauteur (<xsl:value-of select="height/unit"/>)
          </b>
        </td>
        <td class="style3">
          <xsl:value-of select="height/value"/>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>
            Chargement admissible (<xsl:value-of select="admissibleLoad/unit"/>)
          </b>
        </td>
        <td class="style3">
          <xsl:value-of select="admissibleLoad/value"/>
        </td>
      </tr>
    </table>
  </xsl:template>
  <!--TRUCK SOLUTION-->
  <xsl:template match="truckSolution">
    <h3>Solution sélectionnée</h3>
    <table class="style1" cellpadding="4">
      <xsl:if test="title">
        <tr>
          <td class="style2">
            <b>Titre</b>
          </td>
          <td class="style3" colspan="3">
            <xsl:value-of select="title"/>
          </td>
        </tr>
      </xsl:if>
      <tr>
        <td class="style2">
          <b>Nombre de palette</b>
        </td>
        <td class="style3">
          <xsl:value-of select="palletCount"/>
        </td>
        <td class="style2">
          <b>Nombre de caisses</b>
        </td>
        <td class="style3">
          <xsl:value-of select="caseCount"/>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>
            Masse chargement (<xsl:value-of select="loadWeight/unit"/>):
          </b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="loadWeight/value"/>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>Efficacité massique (%)</b>
        </td>
        <td class="style3">
          <xsl:value-of select="loadEfficiency"/>
        </td>
        <td class="style2">
          <b>Efficacité volumique (%)</b>
        </td>
        <td class="style3">
          <xsl:value-of select="volumeEfficiency"/>
        </td>
      </tr>
      <tr>
        <td colspan="4" align="middle">
          <xsl:apply-templates select="view_trucksolution_top"></xsl:apply-templates>
        </td>
      </tr>
      <tr>
        <td colspan="4" align="middle">
          <xsl:apply-templates select="view_trucksolution_iso"></xsl:apply-templates>
        </td>
      </tr>
    </table>
  </xsl:template>
  <!--CARDBOARD-->
  <xsl:template match="cardboard">
    <h3>Carton</h3>
    <b>Carton</b>
    <table border="1" cellpadding="5">
      <tr>
        <td class="style2">
          <b>Nom</b>
        </td>
        <td class="style2">
          <b>
            Epaisseur (<xsl:value-of select="thickness/unit"/>)
          </b>
        </td>
        <td class="style2">
          <b>
            ECT (<xsl:value-of select="ect/unit"/>)
          </b>
        </td>
        <td class="style2">
          <b>
            Rigidité X(<xsl:value-of select="stiffnessX/unit"/>)
          </b>
        </td>
        <td class="style2">
          <b>
            Rigidité Y (<xsl:value-of select="stiffnessY/unit"/>)
          </b>
        </td>
      </tr>
      <tr>
        <td class="style3">
          <xsl:value-of select="name"/>
        </td>
        <td>
          <xsl:value-of select="thickness/value"/>
        </td>
        <td>
          <xsl:value-of select="ect/value"/>
        </td>
        <td>
          <xsl:value-of select="stiffnessX/value"/>
        </td>
        <td>
          <xsl:value-of select="stiffnessY/value"/>
        </td>
      </tr>
    </table>
  </xsl:template>
  <!--BCT_STATIC-->
  <xsl:template match="bct_static">
    <table border="1" cellpadding="2">
      <tr>
        <td class="style2">
          <b>BCP statique</b>
        </td>
        <td class="style3">
          <xsl:text/>
        </td>
      </tr>
    </table>
  </xsl:template>
  <!--BCT_DYNAMIC-->
  <xsl:template match="bct_dynamic">
    <b>BCP dynamique</b>
    <table border="1" cellpadding="7">
      <tr>
        <td class="style2">
          <b>Stockage</b>
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