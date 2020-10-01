<!DOCTYPE html>
<!--[if IE]><![endif]-->
<html>
  
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <title>Enum CellEvent
   </title>
    <meta name="viewport" content="width=device-width">
    <meta name="title" content="Enum CellEvent
   ">
    <meta name="generator" content="docfx 2.56.2.0">
    
    <link rel="shortcut icon" href="../favicon.ico">
    <link rel="stylesheet" href="../styles/docfx.vendor.css">
    <link rel="stylesheet" href="../styles/docfx.css">
    <link rel="stylesheet" href="../styles/main.css">
    <meta property="docfx:navrel" content="../toc.html">
    <meta property="docfx:tocrel" content="toc.html">
    
    
    
  </head>
  <body data-spy="scroll" data-target="#affix" data-offset="120">
    <div id="wrapper">
      <header>
        
        <nav id="autocollapse" class="navbar navbar-inverse ng-scope" role="navigation">
          <div class="container">
            <div class="navbar-header">
              <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#navbar">
                <span class="sr-only">Toggle navigation</span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
              </button>
              
              <a class="navbar-brand" href="../index.html">
                <img id="logo" class="svg" src="../logo.svg" alt="">
              </a>
            </div>
            <div class="collapse navbar-collapse" id="navbar">
              <form class="navbar-form navbar-right" role="search" id="search">
                <div class="form-group">
                  <input type="text" class="form-control" id="search-query" placeholder="Search" autocomplete="off">
                </div>
              </form>
            </div>
          </div>
        </nav>
        
        <div class="subnav navbar navbar-default">
          <div class="container hide-when-search" id="breadcrumb">
            <ul class="breadcrumb">
              <li></li>
            </ul>
          </div>
        </div>
      </header>
      <div role="main" class="container body-content hide-when-search">
        
        <div class="sidenav hide-when-search">
          <a class="btn toc-toggle collapse" data-toggle="collapse" href="#sidetoggle" aria-expanded="false" aria-controls="sidetoggle">Show / Hide Table of Contents</a>
          <div class="sidetoggle collapse" id="sidetoggle">
            <div id="sidetoc"></div>
          </div>
        </div>
        <div class="article row grid-right">
          <div class="col-md-10">
            <article class="content wrap" id="_content" data-uid="Cephei.Cell.CellEvent">
  
  
  <h1 id="Cephei_Cell_CellEvent" data-uid="Cephei.Cell.CellEvent" class="text-break">Enum CellEvent
  </h1>
  <div class="markdown level0 summary"><p sourcefile="obj/api/Cephei.Cell.CellEvent.yml" sourcestartlinenumber="2" sourceendlinenumber="2">Events sent from mutating cells to their dependants OnChange event handlers</p>
</div>
  <div class="markdown level0 conceptual"></div>
  <h6><strong>Namespace</strong>: <a class="xref" href="Cephei.Cell.html">Cephei.Cell</a></h6>
  <h6><strong>Assembly</strong>: Cephei - Backup.Cell.dll</h6>
  <h5 id="Cephei_Cell_CellEvent_syntax">Syntax</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public enum CellEvent : int</code></pre>
  </div>
  <h3 id="fields">Fields
  </h3>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Name</th>
        <th>Description</th>
      </tr>
    <thead>
    <tbody>
      <tr>
        <td id="Cephei_Cell_CellEvent_Calculate">Calculate</td>
        <td><p sourcefile="obj/api/Cephei.Cell.CellEvent.yml" sourcestartlinenumber="2" sourceendlinenumber="3">do the calculation if needed. Recipients of this message send invalidate
messages to their listeners</p>
</td>
      </tr>
      <tr>
        <td id="Cephei_Cell_CellEvent_Create">Create</td>
        <td><p sourcefile="obj/api/Cephei.Cell.CellEvent.yml" sourcestartlinenumber="2" sourceendlinenumber="2">default is that it was simply created</p>
</td>
      </tr>
      <tr>
        <td id="Cephei_Cell_CellEvent_Delete">Delete</td>
        <td><p sourcefile="obj/api/Cephei.Cell.CellEvent.yml" sourcestartlinenumber="2" sourceendlinenumber="4">The item has been removed from a model, and any casual observes should unlink.
This will only happen for dynamic models that allow the calculations to be
changed at runtime</p>
</td>
      </tr>
      <tr>
        <td id="Cephei_Cell_CellEvent_Error">Error</td>
        <td><p sourcefile="obj/api/Cephei.Cell.CellEvent.yml" sourcestartlinenumber="2" sourceendlinenumber="3">an error occurred in the calculation.. all dependant changes should be
abandoned</p>
</td>
      </tr>
      <tr>
        <td id="Cephei_Cell_CellEvent_Invalidate">Invalidate</td>
        <td><p sourcefile="obj/api/Cephei.Cell.CellEvent.yml" sourcestartlinenumber="2" sourceendlinenumber="4">Invalidate message is sent by threaded calculations to invalidate objects
without causing a cascade of blocked threads.  Invalidate results in the cell
becoming <em>Dirty</em></p>
</td>
      </tr>
      <tr>
        <td id="Cephei_Cell_CellEvent_JoinSession">JoinSession</td>
        <td><p sourcefile="obj/api/Cephei.Cell.CellEvent.yml" sourcestartlinenumber="2" sourceendlinenumber="4">Join a calculation session.  This event is passed to all dependant cells so
they can determine whether a session value should be used instead of the spot
value</p>
</td>
      </tr>
      <tr>
        <td id="Cephei_Cell_CellEvent_Link">Link</td>
        <td><p sourcefile="obj/api/Cephei.Cell.CellEvent.yml" sourcestartlinenumber="2" sourceendlinenumber="3">when the value of a cell changes in the model, force Calculators to switch
references</p>
</td>
      </tr>
    </tbody>
  </thead></thead></table>
</article>
          </div>
          
          <div class="hidden-sm col-md-2" role="complementary">
            <div class="sideaffix">
              <div class="contribution">
                <ul class="nav">
                  <li>
                    <a href="https://github.com/channell/Cephei/new/master/apiSpec/new?filename=Cephei_Cell_CellEvent.md&amp;value=---%0Auid%3A%20Cephei.Cell.CellEvent%0Asummary%3A%20'*You%20can%20override%20summary%20for%20the%20API%20here%20using%20*MARKDOWN*%20syntax'%0A---%0A%0A*Please%20type%20below%20more%20information%20about%20this%20API%3A*%0A%0A" class="contribution-link">Improve this Doc</a>
                  </li>
                  <li>
                    <a href="https://github.com/channell/Cephei/blob/master/Cephei.Cell/Enum.cs/#L10" class="contribution-link">View Source</a>
                  </li>
                </ul>
              </div>
              <nav class="bs-docs-sidebar hidden-print hidden-xs hidden-sm affix" id="affix">
              <!-- <p><a class="back-to-top" href="#top">Back to top</a><p> -->
              </nav>
            </div>
          </div>
        </div>
      </div>
      
      <footer>
        <div class="grad-bottom"></div>
        <div class="footer">
          <div class="container">
            <span class="pull-right">
              <a href="#top">Back to top</a>
            </span>
            
            <span>Generated by <strong>DocFX</strong></span>
          </div>
        </div>
      </footer>
    </div>
    
    <script type="text/javascript" src="../styles/docfx.vendor.js"></script>
    <script type="text/javascript" src="../styles/docfx.js"></script>
    <script type="text/javascript" src="../styles/main.js"></script>
  </body>
</html>
