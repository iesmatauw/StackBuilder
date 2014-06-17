<?xml version="1.0" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="html"></xsl:output>
  <xsl:template match="report">
    <html>
      <head>
        <title>
          <xsl:value-of select="name"></xsl:value-of> report
        </title>
        <style type="text/css">
          .style1
          {
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
          <tr>
            <td class="style2" colspan="1">
              <b>Document</b>
            </td>
            <td class="style3" colspan="2">
              <xsl:value-of select="name"/>
            </td>
            <xsl:if test="companyLogo">
              <td colspan="1" align="middle">
                <xsl:apply-templates select="companyLogo"/>
              </td>
            </xsl:if>            
          </tr>
          <tr>
            <td class="style2" colspan="1">
              <b>Description</b>
            </td>
            <td class="style3" colspan="2">
              <xsl:value-of select="description"/>
            </td>
            <td class="style2" colspan="1"/>
          </tr>
          <tr>
            <td class="style2" colspan="1">
              <b>Date</b>
            </td>
            <td class="style3" colspan="1">
              <xsl:value-of select="dateOfCreation"/>
            </td>
            <td class="style2" colspan="1">
              <b>Author</b>
            </td>
            <td class="style3" colspan="1">
              <xsl:value-of select="author"></xsl:value-of>
            </td>
          </tr>
        </table>
        <xsl:apply-templates select="caseAnalysis"></xsl:apply-templates>
        <xsl:apply-templates select="palletAnalysis"></xsl:apply-templates>
        <xsl:apply-templates select="cylinderPalletAnalysis"></xsl:apply-templates>
        <xsl:apply-templates select="truckAnalysis"></xsl:apply-templates>
        <xsl:apply-templates select="ectAnalysis"></xsl:apply-templates>
      </body>
    </html>
  </xsl:template>
  <xsl:template match="caseAnalysis">
    <h2>Case analysis</h2>
    <xsl:apply-templates select="box"></xsl:apply-templates>
    <xsl:apply-templates select="caseWithInnerDims"></xsl:apply-templates>
    <xsl:apply-templates select="caseConstraintSet"></xsl:apply-templates>
    <xsl:apply-templates select="caseSolution"></xsl:apply-templates>
  </xsl:template>
  <xsl:template match="palletAnalysis">
    <h2>Pallet analysis</h2>
    <xsl:apply-templates select="case"></xsl:apply-templates>
    <xsl:apply-templates select="bundle"></xsl:apply-templates>
    <xsl:apply-templates select="box"></xsl:apply-templates>
    <xsl:apply-templates select="caseOfBoxes"></xsl:apply-templates>
    <xsl:apply-templates select="interlayer"></xsl:apply-templates>
    <xsl:apply-templates select="pallet"></xsl:apply-templates>
    <xsl:apply-templates select="constraintSet"></xsl:apply-templates>
    <xsl:apply-templates select="caseOptimConstraintSet"></xsl:apply-templates>
    <xsl:apply-templates select="palletSolution"></xsl:apply-templates>
  </xsl:template>
  <xsl:template match="cylinderAnalysis">
    <h2>Cylinder analysis</h2>
    <xsl:apply-templates select="cylinder"></xsl:apply-templates>
    <xsl:apply-templates select="pallet"></xsl:apply-templates>
    <xsl:apply-templates select="interlayer"></xsl:apply-templates>
    <xsl:apply-templates select="cylinderPalletConstraintSet"></xsl:apply-templates>
    <xsl:apply-templates select="cylinderPalletSolution"></xsl:apply-templates>
  </xsl:template>
  <xsl:template match="truckAnalysis">
    <h2>Truck analysis</h2>
    <xsl:apply-templates select="truck"></xsl:apply-templates>
    <xsl:apply-templates select="truckSolution"></xsl:apply-templates>
  </xsl:template>
  <xsl:template match="ectAnalysis">
    <h2>Box Compression Test analysis</h2>
    <xsl:apply-templates select="cardboard"></xsl:apply-templates>
    <table class="style1" cellpadding="2">
      <tr>
        <td class="style2">
          <b>Case type</b>
        </td>
        <td class="style2">
          <b>Printed surface</b>
        </td>
        <td class="style2">
          <b>Formule de Mc Kee</b>
        </td>
      </tr>
      <tr>
        <td class="style3">
          <xsl:value-of select="caseType"></xsl:value-of>
        </td>
        <td class="style3">
          <xsl:value-of select="printedSurface"></xsl:value-of>
        </td>
        <td class="style3">
          <xsl:value-of select="mcKeeFormulaMode"></xsl:value-of>
        </td>
      </tr>
    </table>
    <xsl:apply-templates select="bct_static"></xsl:apply-templates>
    <xsl:apply-templates select="bct_dynamic"></xsl:apply-templates>
  </xsl:template>
  <!-- #### CASE ####-->
  <xsl:template match="case">
    <h3>Case</h3>
    <table class="style1" cellpadding="3">
      <tr>
        <td class="style2" colspan="1">
          <b>Name</b>
        </td>
        <td class="style3" colspan="2">
          <xsl:value-of select="name"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1">
          <b>Description</b>
        </td>
        <td class="style3" colspan="2">
          <xsl:value-of select="description"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1">
          <b>
            Length (<xsl:value-of select="length/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="length/value"></xsl:value-of>
        </td>
        <td rowspan="5" align="middle">
          <xsl:apply-templates select="view_case_iso"></xsl:apply-templates>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>
            Width (<xsl:value-of select="width/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="width/value"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>
            Height (<xsl:value-of select="height/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="height/value"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>
            Weight (<xsl:value-of select="weight/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="weight/value"></xsl:value-of>
        </td>
      </tr>
      <xsl:if test="admissibleLoad">
        <tr>
          <td class="style2">
            <b>
              Admissible load on top (<xsl:value-of select="admissibleLoad/unit"></xsl:value-of>)
            </b>
          </td>
          <td class="style3" colspan="1">
            <xsl:value-of select="admissibleLoad/value"></xsl:value-of>
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
          <xsl:value-of select="name"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1">
          <b>Description</b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="description"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1">
          <b>
            Radius (<xsl:value-of select="radius/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="radius/value"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1">
          <b>
            Height (<xsl:value-of select="height/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="height/value"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1">
          <b>
            Weight (<xsl:value-of select="weight/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="weight/value"></xsl:value-of>
        </td>
        <td colspan="2" align="middle">
          <xsl:apply-templates select="view_cylinder_iso"></xsl:apply-templates>
        </td>
      </tr>
    </table>
  </xsl:template>
  <!--#### CASE WITH INNER DIMS #### -->
  <xsl:template match="caseWithInnerDims">
    <h3>Case</h3>
    <table class="style1" cellpadding="4">
      <tr>
        <td class="style2" colspan="1">
          <b>Name</b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="name"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1">
          <b>Description</b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="description"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1">
          <b>
            Ext. length (<xsl:value-of select="length/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="length/value"></xsl:value-of>
        </td>
        <td class="style2" colspan="1">
          <b>
            Interior length (<xsl:value-of select="innerLength/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="innerLength/value"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1">
          <b>
            Ext. width (<xsl:value-of select="width/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="width/value"></xsl:value-of>
        </td>
        <td class="style2" colspan="1">
          <b>
            Interior width (<xsl:value-of select="innerWidth/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="innerWidth/value"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1">
          <b>
            Ext. height (<xsl:value-of select="height/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="height/value"></xsl:value-of>
        </td>
        <td class="style2" colspan="1">
          <b>
            Interior height (<xsl:value-of select="innerHeight/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="innerHeight/value"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1">
          <b>
            Weight (<xsl:value-of select="weight/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="weight/value"></xsl:value-of>
        </td>
        <td colspan="2" align="middle">
          <xsl:apply-templates select="view_case_iso"></xsl:apply-templates>
        </td>
      </tr>
    </table>
  </xsl:template>
  <!-- #### PALLET ####-->
  <xsl:template match="pallet">
    <h3>Pallet</h3>
    <table class="style1" cellpadding="3">
      <tr>
        <td class="style2" colspan="1">
          <b>Name</b>
        </td>
        <td class="style3" colspan="2">
          <xsl:value-of select="name"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1">
          <b>Description</b>
        </td>
        <td class="style3" colspan="2">
          <xsl:value-of select="description"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1">
          <b>
            Length (<xsl:value-of select="length/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="length/value"></xsl:value-of>
        </td>
        <td rowspan="5" align="middle">
          <xsl:apply-templates select="view_pallet_iso"></xsl:apply-templates>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1">
          <b>
            Width (<xsl:value-of select="width/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="width/value"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1">
          <b>
            Height (<xsl:value-of select="height/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="height/value"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1">
          <b>
            Weight (<xsl:value-of select="admissibleLoad/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="admissibleLoad/value"></xsl:value-of>
        </td>
      </tr>
      <xsl:if test="admissibleLoad">
        <tr>
          <td class="style2" colspan="1">
            <b>
              Admissible load weight (<xsl:value-of select="admissibleLoad/unit"></xsl:value-of>)
            </b>
          </td>
          <td class="style3" colspan="1">
            <xsl:value-of select="admissibleLoad/value"></xsl:value-of>
          </td>
        </tr>
      </xsl:if>
    </table>
  </xsl:template>
  <!--BOX-->
  <xsl:template match="box">
    <h3>Box</h3>
    <table class="style1">
      <tr>
        <td class="style2" colspan="1">
          <b>Name</b>
        </td>
        <td class="style3" colspan="2">
          <xsl:value-of select="name"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1">
          <b>Description</b>
        </td>
        <td class="style3" colspan="2">
          <xsl:value-of select="description"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1">
          <b>
            Length (<xsl:value-of select="length/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="length/value"></xsl:value-of>
        </td>
        <td rowspan="4" align="middle">
          <xsl:apply-templates select="view_box_iso"></xsl:apply-templates>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>
            Width (<xsl:value-of select="width/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="width/value"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>
            Height (<xsl:value-of select="height/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="height/value"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>
            Weight (<xsl:value-of select="weight/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" colspan="1">
          <xsl:value-of select="weight/value"></xsl:value-of>
        </td>
      </tr>
    </table>
  </xsl:template>
  <!--#### INTERLAYER ####-->
  <xsl:template match="interlayer">
    <h3>Interlayer</h3>
    <table class="style1">
      <tr>
        <td class="style2">
          <b>Name</b>
        </td>
        <td class="style3" colspan="2">
          <xsl:value-of select="name"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>Description</b>
        </td>
        <td class="style3" colspan="2">
          <xsl:value-of select="description"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>
            Length (<xsl:value-of select="length/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3">
          <xsl:value-of select="length/value"></xsl:value-of>
        </td>
        <td rowspan="4" align="middle">
          <xsl:apply-templates select="view_interlayer_iso"></xsl:apply-templates>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>
            Width (<xsl:value-of select="width/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3">
          <xsl:value-of select="width/value"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>
            Thickness (<xsl:value-of select="thickness/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3">
          <xsl:value-of select="thickness/value"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>
            Weight (<xsl:value-of select="weight/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3">
          <xsl:value-of select="weight/value"></xsl:value-of>
        </td>
      </tr>
    </table>
  </xsl:template>
  <!--#### BUNDLE ####-->
  <xsl:template match="bundle">
    <h3>Bundle</h3>
    <table class="style1">
      <tr>
        <td class="style2">
          <b>Name</b>
        </td>
        <td colspan="2">
          <xsl:value-of select="name"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>Description</b>
        </td>
        <td colspan="2">
          <xsl:value-of select="description"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <strong>
            Length (<xsl:value-of select="length/unit"></xsl:value-of>)
          </strong>
        </td>
        <td class="style3">
          <xsl:value-of select="length/value"></xsl:value-of>
        </td>
        <td rowspan="6" align="middle">
          <xsl:apply-templates select="view_bundle_iso"></xsl:apply-templates>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>
            Width (<xsl:value-of select="width/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3">
          <xsl:value-of select="width/value"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>Number of flats</b>
        </td>
        <td class="style3">
          <xsl:value-of select="numberOfFlats"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>
            Unit thickness (<xsl:value-of select="unitThickness/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3">
          <xsl:value-of select="unitThickness/value"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>
            Unit weight (<xsl:value-of select="unitWeight/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3">
          <xsl:value-of select="unitWeight/value"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style3">
          <b>
            Total thickness (<xsl:value-of select="totalThickness/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3">
          <xsl:value-of select="totalThickness/value"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style3">
          <b>
            Total weight (<xsl:value-of select="totalWeight/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3">
          <xsl:value-of select="totalWeight/value"></xsl:value-of>
        </td>
      </tr>
    </table>
  </xsl:template>
  <!-- #### CASE OF BOXES #### -->
  <xsl:template match="caseOfBoxes">
    <h3>Case of boxes</h3>
    <table class="style1" cellpadding="4">
      <tr>
        <td class="style2" colspan="1" width="25%">
          <b>Name</b>
        </td>
        <td class="style3" colspan="3" width="75%">
          <xsl:value-of select="name"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1" width="25%">
          <b>Description</b>
        </td>
        <td class="style3" colspan="3" width="75%">
          <xsl:value-of select="description"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2" width="25%">
          <b>
            Length (<xsl:value-of select="outerlength/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" width="25%">
          <xsl:value-of select="outerlength/value"></xsl:value-of>
        </td>
        <td class="style2" width="25%">
          <b>
            Inner length (<xsl:value-of select="innerlength/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" width="25%">
          <xsl:value-of select="innerLength/value"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2" width="25%">
          <b>
            Width (<xsl:value-of select="outerWidth/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" width="25%">
          <xsl:value-of select="outerWidth/value"></xsl:value-of>
        </td>
        <td class="style2" width="25%">
          <b>
            Inner width (<xsl:value-of select="outerWidth/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" width="25%">
          <xsl:value-of select="innerWidth/value"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2" width="25%">
          <b>
            Height (<xsl:value-of select="outerHeight/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" width="25%">
          <xsl:value-of select="outerHeight/value"></xsl:value-of>
        </td>
        <td class="style2" width="25%">
          <b>
            Inner height (<xsl:value-of select="innerHeight/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" width="25%">
          <xsl:value-of select="innerHeight/value"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2" width="25%">
          <b>
            Volume (<xsl:value-of select="outerVolume/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" width="25%">
          <xsl:value-of select="outerVolume/value"></xsl:value-of>
        </td>
        <td class="style2">
          <b>
            Inner volume (<xsl:value-of select="innerVolume/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3">
          <xsl:value-of select="innerVolume/value"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>
            Empty weight (<xsl:value-of select="emptyWeight/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3">
          <xsl:value-of select="emptyWeight/value"></xsl:value-of>
        </td>
        <td class="style2" width="25%">
          <b>
            Weight (<xsl:value-of select="weight/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" width="25%">
          <xsl:value-of select="weight/value"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2" width="25%">
          <b>Number of boxes</b>
        </td>
        <td class="style3" width="25%">
          <xsl:value-of select="numberOfBoxes"></xsl:value-of>
        </td>
        <td class="style2" width="25%">
          <b>Layout</b>
        </td>
        <td class="style3" width="25%">
          <xsl:value-of select="noX"></xsl:value-of>*<xsl:value-of select="noY"></xsl:value-of>*<xsl:value-of select="noZ"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2" width="25%">
          <b>Dim0</b>
        </td>
        <td class="style3" width="25%">
          <xsl:value-of select="dim0"></xsl:value-of>
        </td>
        <td class="style2" width="25%">
          <b>Dim1</b>
        </td>
        <td class="style3" width="25%">
          <xsl:value-of select="dim1"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td colspan="2" align="middle">
          <xsl:apply-templates select="view_caseOfBoxes_iso1"></xsl:apply-templates>
        </td>
        <td colspan="2" align="middle">
          <xsl:apply-templates select="view_caseOfBoxes_iso2"></xsl:apply-templates>
        </td>
      </tr>
    </table>
  </xsl:template>
  <!--#### CONSTRAINT SET ####-->
  <xsl:template match="constraintSet">
    <h3>Constraint set</h3>
    <table class="style1">
      <tr>
        <td class="style2">
          <b>
            Overhang Length/ Width(<xsl:value-of select="overhangX/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3">
          <xsl:value-of select="overhangX/value"></xsl:value-of> / <xsl:value-of select="overhangY/value"></xsl:value-of>
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
          <b>Allowed ortho axes</b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="allowedOrthoAxis"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>Allow aligned layers</b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="allowAlignedLayers"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>Allow alternate layers</b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="allowAlternateLayers"></xsl:value-of>
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
            Overhang Length/Width(<xsl:value-of select="overhangX/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3">
          <xsl:value-of select="overhangX/value"></xsl:value-of> / <xsl:value-of select="overhangY/value"></xsl:value-of>
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
    <h3>Case optimization constraint set</h3>
    <table class="style1" cellpadding="2">
      <tr>
        <td class="style2">
          <b>
            Wall thickness (<xsl:value-of select="wallThickness/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3">
          <xsl:value-of select="wallThickness/value"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>Case limit (min)</b>
        </td>
        <td class="style3">
          <xsl:value-of select="caseLimitMin"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style3">
          <b>Case limit (max)</b>
        </td>
        <td class="style3">
          <xsl:value-of select="caseLimitMax"></xsl:value-of>
        </td>
      </tr>
    </table>
  </xsl:template>
  <!--#### CASE CONSTRAINTSET ####-->
  <xsl:template match="caseConstraintSet">
    <h3>Contraintes remplissage caisses</h3>
    <table class="style1" cellpadding="2">
      <tr>
        <td class="style2">
          <b>Allowed orthogonal axis</b>
        </td>
        <td class="style3">
          <xsl:apply-templates select="allowedOrthoAxis"></xsl:apply-templates>
        </td>
      </tr>
      <xsl:apply-templates select="maximumCaseWeightGroup"></xsl:apply-templates>
      <xsl:apply-templates select="minimumBoxPerCaseGroup"></xsl:apply-templates>
      <xsl:apply-templates select="maximumBoxPerCaseGroup"></xsl:apply-templates>
    </table>
  </xsl:template>
  <xsl:template match="maximumCaseWeightGroup">
    <tr>
      <td class="style2">
        <b>
          Maximum case weight (<xsl:value-of select="maximumCaseWeight/unit"></xsl:value-of>)
        </b>
      </td>
      <td class="style3">
        <xsl:value-of select="maximumCaseWeight/value"></xsl:value-of>
      </td>
    </tr>
  </xsl:template>
  <xsl:template match="minimumBoxPerCaseGroup">
    <tr>
      <td class="style2">
        <b>Minimum number of items</b>
      </td>
      <td class="style3">
        <xsl:value-of select="minimumBoxPerCase"></xsl:value-of>
      </td>
    </tr>
  </xsl:template>
  <xsl:template match="maximumBoxPerCaseGroup">
    <tr>
      <td class="style2">
        <b>Maximum number of items</b>
      </td>
      <td class="style3">
        <xsl:value-of select="maximumBoxPerCase"></xsl:value-of>
      </td>
    </tr>
  </xsl:template>
  <!--#### PALLET SOLUTION ####-->
  <xsl:template match="palletSolution">
    <h3>Selected solution</h3>
    <table class="style1">
      <tr>
        <td class="style2">
          <b>Title</b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="title"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>Number of cases</b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="caseCount"></xsl:value-of>
        </td>
      </tr>
      <xsl:if test="interlayerCount">
        <tr>
          <td class="style2">
            <b>Number of interlayers</b>
          </td>
          <td class="style3" colspan="3">
            <xsl:value-of select="interlayerCount"></xsl:value-of>
          </td>
        </tr>
      </xsl:if>
      <tr>
        <td class="style2">
          <b>
            Pallet weight (<xsl:value-of select="palletWeight/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="palletWeight/value"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>
            Pallet height (<xsl:value-of select="palletHeight/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="palletHeight/value"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>Efficiency (%)</b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="efficiency"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td align="middle">
          <xsl:apply-templates select="view_palletsolution_front"></xsl:apply-templates>
        </td>
        <td align="middle">
          <xsl:apply-templates select="view_palletsolution_left"></xsl:apply-templates>
        </td>
        <td align="middle">
          <xsl:apply-templates select="view_palletsolution_right"></xsl:apply-templates>
        </td>
        <td align="middle">
          <xsl:apply-templates select="view_palletsolution_back"></xsl:apply-templates>
        </td>
      </tr>
      <tr>
        <td colspan="4" align="middle">
          <xsl:apply-templates select="view_palletsolution_iso"></xsl:apply-templates>
        </td>
      </tr>
    </table>
    <h3>Layer(s)</h3>
    <table class="style1">
      <tr>
        <td class="style2">
          <b>Index</b>
        </td>
        <td class="style3">
          <b>Nombre de caisses</b>
        </td>
        <td class="style3" align="middle">
          <b>Image</b>
        </td>
      </tr>
      <xsl:apply-templates select="layer"></xsl:apply-templates>
    </table>
  </xsl:template>
  <!-- #### CYLINDER PALLET SOLUTION #### -->
  <xsl:template match="cylinderPaletSolution">
    <h3>Selected solution</h3>
    <table class="style1">
      <tr>
        <td class="style2">
          <b>Title</b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="title"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>Number of cylinders</b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="cylinderCount"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>
            Pallet weight (<xsl:value-of select="palletWeight/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="palletWeight/value"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>
            Pallet height (<xsl:value-of select="palletHeight/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="palletHeight/value"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>Efficiency (%)</b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="efficiency"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td align="middle">
          <xsl:apply-templates select="view_palletsolution_front"></xsl:apply-templates>
        </td>
        <td align="middle">
          <xsl:apply-templates select="view_palletsolution_left"></xsl:apply-templates>
        </td>
        <td align="middle">
          <xsl:apply-templates select="view_palletsolution_right"></xsl:apply-templates>
        </td>
        <td align="middle">
          <xsl:apply-templates select="view_palletsolution_back"></xsl:apply-templates>
        </td>
      </tr>
      <tr>
        <td colspan="4" align="middle">
          <xsl:apply-templates select="view_palletsolution_iso"></xsl:apply-templates>
        </td>
      </tr>
    </table>
    <h3>Layer(s)</h3>
    <table class="style1">
      <tr>
        <td class="style2">
          <b>Index</b>
        </td>
        <td class="style3">
          <b>Number of case(s)</b>
        </td>
        <td class="style3" align="middle">
          <b>Image</b>
        </td>
      </tr>
      <xsl:apply-templates select="layer"></xsl:apply-templates>
    </table>
  </xsl:template>
  <!--#### CASE SOLUTION ####-->
  <xsl:template match="caseSolution">
    <h3>Case filling</h3>
    <table class="style1" cellpadding="5">
      <tr>
        <td class="style2" colspan="1" width="40%">
          <b>Title</b>
        </td>
        <td class="style3" colspan="4" width="60%">
          <xsl:value-of select="title"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1" width="40%">
          <b>Layer homogeneous</b>
        </td>
        <td class="style3" colspan="4" width="60%">
          <xsl:value-of select="homogeneousLayer"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style3" colspan="1" width="40%"></td>
        <td class="style2" colspan="2" width="30%">
          <b>Case</b>
        </td>
        <td class="style2" colspan="2" width="30%">
          <b>Pallet</b>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1" width="40%">
          <b>Number of box</b>
        </td>
        <td class="style3" colspan="2" width="30%">
          <xsl:value-of select="boxPerCaseCount"></xsl:value-of>
        </td>
        <td class="style3" colspan="2" width="30%">
          <xsl:value-of select="boxPerPalletCount"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1" width="40%">
          <b>Efficiency (%)</b>
        </td>
        <td class="style3" colspan="2" width="30%">
          <xsl:value-of select="caseEfficiency"></xsl:value-of>
        </td>
        <td class="style3" colspan="2" width="30%">
          <xsl:value-of select="palletEfficiency"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2" colspan="1" width="40%">
          <b>
            Weight (<xsl:value-of select="caseWeight/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" colspan="2" width="30%">
          <xsl:value-of select="caseWeight/value"></xsl:value-of>
        </td>
        <td class="style3" colspan="2" width="30%">
          <xsl:value-of select="palletWeight/value"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td colspan="5" align="middle">
          <xsl:apply-templates select="view_caseSolution_iso"></xsl:apply-templates>
        </td>
      </tr>
    </table>
  </xsl:template>
  <!--CASE-->
  <xsl:template match="view_case_iso">
    <img src="images\view_case_iso.png" width="150" height="150" align="middle"></img>
  </xsl:template>
  <!--CYLINDER-->
  <xsl:template match="view_cylinder_iso">
    <img src="images\view_cylinder_iso.png" width="150" height="150" align="middle"></img>
  </xsl:template>
  <!--BOX-->
  <xsl:template match="view_box_iso">
    <img src="images\view_box_iso.png" width="150" height="150" align="middle"></img>
  </xsl:template>
  <!--PALLET-->
  <xsl:template match="view_pallet_iso">
    <img src="images\view_pallet_iso.png" width="150" height="150" align="middle"></img>
  </xsl:template>
  <!--INTERLAYER-->
  <xsl:template match="view_interlayer_iso">
    <img src="images\view_interlayer_iso.png" width="150" height="150" align="middle"></img>
  </xsl:template>
  <!--BUNDLE-->
  <xsl:template match="view_bundle_iso">
    <img src="images\view_interlayer_iso.png" width="150" height="150" align="middle"></img>
  </xsl:template>
  <!--PALLET SOLUTION-->
  <xsl:template match="view_palletsolution_front">
    <img src="images\view_palletsolution_front.png" width="150" height="150" align="middle"></img>
  </xsl:template>
  <xsl:template match="view_palletsolution_left">
    <img src="images\view_palletsolution_left.png" width="150" height="150" align="middle"></img>
  </xsl:template>
  <xsl:template match="view_palletsolution_right">
    <img src="images\view_palletsolution_right.png" width="150" height="150" align="middle"></img>
  </xsl:template>
  <xsl:template match="view_palletsolution_back">
    <img src="images\view_palletsolution_back.png" width="150" height="150" align="middle"></img>
  </xsl:template>
  <xsl:template match="view_palletsolution_iso">
    <img src="images\view_palletsolution_iso.png" width="450" height="450" align="middle"></img>
  </xsl:template>
  <!--CASE OF BOXES-->
  <xsl:template match="view_caseOfBoxes_iso1">
    <img src="images\view_caseOfBoxes_iso1.png" width="150" height="150" align="middle"></img>
  </xsl:template>
  <xsl:template match="view_caseOfBoxes_iso2">
    <img src="images\view_caseOfBoxes_iso2.png" width="150" height="150" align="middle"></img>
  </xsl:template>
  <xsl:template match="view_caseSolution_iso">
    <img src="images\view_caseSolution_iso.png" width="300" height="300" align="middle"></img>
  </xsl:template>
  <xsl:template match="view_truck_iso">
    <img src="images\view_truck_iso.png" width="150" height="150" align="middle"></img>
  </xsl:template>
  <xsl:template match="view_trucksolution_top">
    <img src="images\view_trucksolution_top.png" width="450" height="450" align="middle"></img>
  </xsl:template>
  <xsl:template match="view_trucksolution_iso">
    <img src="images\view_trucksolution_iso.png" width="450" height="450" align="middle"></img>
  </xsl:template>
  <!--STOP STACKING CONDITIONS-->
  <xsl:template match="maximumPalletWeightGroup">
    <xsl:if test="maximumPalletWeight">
      <tr>
        <td class="style2">
          <b>
            Maximum pallet weight (<xsl:value-of select="maximumPalletWeight/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="maximumPalletWeight/value"></xsl:value-of>
        </td>
      </tr>
    </xsl:if>
  </xsl:template>
  <xsl:template match="maximumPalletHeightGroup">
    <tr>
      <td class="style2">
        <b>
          Maximum pallet height (<xsl:value-of select="maximumPalletHeight/unit"></xsl:value-of>)
        </b>
      </td>
      <td class="style3" colspan="3">
        <xsl:value-of select="maximumPalletHeight/value"></xsl:value-of>
      </td>
    </tr>
  </xsl:template>
  <xsl:template match="maximumNumberOfItemsGroup">
    <tr>
      <td class="style2">
        <b>Maximum number of items</b>
      </td>
      <td class="style3" colspan="3">
        <xsl:value-of select="maximumNumberOfItems"></xsl:value-of>
      </td>
    </tr>
  </xsl:template>
  <xsl:template match="admissibleLoadOnTopGroup">
    <tr>
      <td class="style2">
        <b>
          Maximum load on top group (<xsl:value-of select="admissibleLoadOnTop/unit"></xsl:value-of>)
        </b>
      </td>
      <td class="style3" colspan="3">
        <xsl:value-of select="admissibleLoadOnTop/value"></xsl:value-of>
      </td>
    </tr>
  </xsl:template>
  <!--INTERLAYER PERIOD-->
  <xsl:template match="interlayerPeriodGroup">
    <tr>
      <td class="style2">
        <b>Interlayer period</b>
      </td>
      <td class="style3" colspan="3">
        <xsl:value-of select="interlayerPeriod"></xsl:value-of>
      </td>
    </tr>
  </xsl:template>
  <!--LAYER-->
  <xsl:template match="layer">
    <tr>
      <td class="style2">
        <xsl:value-of select="layerId"></xsl:value-of>
      </td>
      <td class="style3">
        <xsl:value-of select="layerCaseCount"></xsl:value-of>
      </td>
      <td align="middle">
        <xsl:if test="layerId='1'">
          <img src="images\layerImage1.png" width="150" height="150"/>
        </xsl:if>
        <xsl:if test="layerId='2'">
          <img src="images\layerImage2.png" width="150" height="150"/>
        </xsl:if>
      </td>
    </tr>
  </xsl:template>
  <!--TRUCK-->
  <xsl:template match="truck">
    <table class="style1" cellpadding="3">
      <tr>
        <td class="style2">
          <b>Name</b>
        </td>
        <td class="style3" colspan="2">
          <xsl:value-of select="name"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>Description</b>
        </td>
        <td class="style3" colspan="2">
          <xsl:value-of select="description"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>
            Length (<xsl:value-of select="length/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3">
          <xsl:value-of select="length/value"></xsl:value-of>
        </td>
        <td rowspan="4" align="middle">
          <xsl:apply-templates select="view_truck_iso"></xsl:apply-templates>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>
            Width (<xsl:value-of select="width/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3">
          <xsl:value-of select="width/value"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>
            Height (<xsl:value-of select="height/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3">
          <xsl:value-of select="height/value"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>
            Admissible load (<xsl:value-of select="admissibleLoad/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style3">
          <xsl:value-of select="admissibleLoad/value"></xsl:value-of>
        </td>
      </tr>
    </table>
  </xsl:template>
  <!--TRUCK SOLUTION-->
  <xsl:template match="truckSolution">
    <h3>Selected solution</h3>
    <table class="style1" cellpadding="4">
      <xsl:if test="title">
        <tr>
          <td class="style2">
            <b>Title</b>
          </td>
          <td class="style3" colspan="3">
            <xsl:value-of select="title"></xsl:value-of>
          </td>
        </tr>
      </xsl:if>
      <tr>
        <td class="style2">
          <b>Pallet count</b>
        </td>
        <td class="style3">
          <xsl:value-of select="palletCount"></xsl:value-of>
        </td>
        <td class="style2">
          <b>Case count</b>
        </td>
        <td class="style3">
          <xsl:value-of select="caseCount"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>
            Load weight (<xsl:value-of select="loadWeight/unit"></xsl:value-of>):
          </b>
        </td>
        <td class="style3" colspan="3">
          <xsl:value-of select="loadWeight/value"></xsl:value-of>
        </td>
      </tr>
      <tr>
        <td class="style2">
          <b>Load efficiency (%)</b>
        </td>
        <td class="style3">
          <xsl:value-of select="loadEfficiency"></xsl:value-of>
        </td>
        <td class="style2">
          <b>Volume efficiency (%)</b>
        </td>
        <td class="style3">
          <xsl:value-of select="volumeEfficiency"></xsl:value-of>
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
    <b>Cardboard</b>
    <table border="1" cellpadding="5">
      <tr>
        <td class="style2">
          <b>Name</b>
        </td>
        <td class="style2">
          <b>
            Thickness (<xsl:value-of select="thickness/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style2">
          <b>
            ECT (<xsl:value-of select="ect/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style2">
          <b>
            StiffnessX (<xsl:value-of select="stiffnessX/unit"></xsl:value-of>)
          </b>
        </td>
        <td class="style2">
          <b>
            StiffnessY (<xsl:value-of select="stiffnessY/unit"></xsl:value-of>)
          </b>
        </td>
      </tr>
      <tr>
        <td class="style3">
          <xsl:value-of select="name"></xsl:value-of>
        </td>
        <td>
          <xsl:value-of select="thickness/value"></xsl:value-of>
        </td>
        <td>
          <xsl:value-of select="ect/value"></xsl:value-of>
        </td>
        <td>
          <xsl:value-of select="stiffnessX/value"></xsl:value-of>
        </td>
        <td>
          <xsl:value-of select="stiffnessY/value"></xsl:value-of>
        </td>
      </tr>
    </table>
  </xsl:template>
  <!--BCT_STATIC-->
  <xsl:template match="bct_static">
    <table border="1" cellpadding="2">
      <tr>
        <td class="style2">
          <b>Static BCP</b>
        </td>
        <td class="style3">
          <xsl:text></xsl:text>
        </td>
      </tr>
    </table>
  </xsl:template>
  <!--BCT_DYNAMIC-->
  <xsl:template match="bct_dynamic">
    <b>Dynamic BCP</b>
    <table border="1" cellpadding="7">
      <tr>
        <td class="style2">
          <b>Storage</b>
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
      <xsl:apply-templates select="bct_dynamic_storage"></xsl:apply-templates>
    </table>
  </xsl:template>
  <!--BCT_DYNAMIC_STORAGE-->
  <xsl:template match="bct_dynamic_storage">
    <tr>
      <td class="style2">
        <b>
          <xsl:value-of select="duration"></xsl:value-of>
        </b>
      </td>
      <xsl:apply-templates select="humidity_0_45"></xsl:apply-templates>
      <xsl:apply-templates select="humidity_46_55"></xsl:apply-templates>
      <xsl:apply-templates select="humidity_56_65"></xsl:apply-templates>
      <xsl:apply-templates select="humidity_66_75"></xsl:apply-templates>
      <xsl:apply-templates select="humidity_76_85"></xsl:apply-templates>
      <xsl:apply-templates select="humidity_86_100"></xsl:apply-templates>
    </tr>
  </xsl:template>
  <!--humidity_0_45-->
  <xsl:template match="humidity_0_45">
    <xsl:choose>
      <xsl:when test="@admissible=&apos;true&apos;">
        <td class="style3">
          <xsl:value-of select="."></xsl:value-of>
        </td>
      </xsl:when>
      <xsl:otherwise>
        <td class="style4">
          <xsl:value-of select="."></xsl:value-of>
        </td>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>
  <!--humidity_46_55-->
  <xsl:template match="humidity_46_55">
    <xsl:choose>
      <xsl:when test="@admissible=&apos;true&apos;">
        <td class="style3">
          <xsl:value-of select="."></xsl:value-of>
        </td>
      </xsl:when>
      <xsl:otherwise>
        <td class="style4">
          <xsl:value-of select="."></xsl:value-of>
        </td>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>
  <!--humidity_56_65-->
  <xsl:template match="humidity_56_65">
    <xsl:choose>
      <xsl:when test="@admissible=&apos;true&apos;">
        <td class="style3">
          <xsl:value-of select="."></xsl:value-of>
        </td>
      </xsl:when>
      <xsl:otherwise>
        <td class="style4">
          <xsl:value-of select="."></xsl:value-of>
        </td>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>
  <!--humidity_66_75-->
  <xsl:template match="humidity_66_75">
    <xsl:choose>
      <xsl:when test="@admissible=&apos;true&apos;">
        <td class="style3">
          <xsl:value-of select="."></xsl:value-of>
        </td>
      </xsl:when>
      <xsl:otherwise>
        <td class="style4">
          <xsl:value-of select="."></xsl:value-of>
        </td>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>
  <!--humidity_76_85-->
  <xsl:template match="humidity_76_85">
    <xsl:choose>
      <xsl:when test="@admissible=&apos;true&apos;">
        <td class="style3">
          <xsl:value-of select="."></xsl:value-of>
        </td>
      </xsl:when>
      <xsl:otherwise>
        <td class="style4">
          <xsl:value-of select="."></xsl:value-of>
        </td>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>
  <!--humidity_76_85-->
  <xsl:template match="humidity_86_100">
    <xsl:choose>
      <xsl:when test="@admissible=&apos;true&apos;">
        <td class="style3">
          <xsl:value-of select="."></xsl:value-of>
        </td>
      </xsl:when>
      <xsl:otherwise>
        <td class="style4">
          <xsl:value-of select="."></xsl:value-of>
        </td>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>
</xsl:stylesheet>