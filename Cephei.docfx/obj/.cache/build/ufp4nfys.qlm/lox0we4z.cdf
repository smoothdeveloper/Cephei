<!DOCTYPE html>
<!--[if IE]><![endif]-->
<html>
  
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <title>Class UnitDisplacedBlackYoYInflationCouponPricerModel
   </title>
    <meta name="viewport" content="width=device-width">
    <meta name="title" content="Class UnitDisplacedBlackYoYInflationCouponPricerModel
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
            <article class="content wrap" id="_content" data-uid="Cephei.QL.UnitDisplacedBlackYoYInflationCouponPricerModel">
  
  
  <h1 id="Cephei_QL_UnitDisplacedBlackYoYInflationCouponPricerModel" data-uid="Cephei.QL.UnitDisplacedBlackYoYInflationCouponPricerModel" class="text-break">Class UnitDisplacedBlackYoYInflationCouponPricerModel
  </h1>
  <div class="markdown level0 summary"></div>
  <div class="markdown level0 conceptual"></div>
  <div class="inheritance">
    <h5>Inheritance</h5>
    <div class="level0"><span class="xref">System.Object</span></div>
    <div class="level1"><span class="xref">System.Collections.Concurrent.ConcurrentDictionary</span>&lt;<span class="xref">string</span>,<a class="xref" href="Cephei.Cell.ICell.html">ICell</a>&gt;</div>
    <div class="level2"><a class="xref" href="Cephei.Cell.Model.html">Model</a></div>
    <div class="level3"><a class="xref" href="Cephei.Cell.Generic.Model-1.html">Model</a>&lt;<span class="xref">QLNet.UnitDisplacedBlackYoYInflationCouponPricer</span>&gt;</div>
    <div class="level4"><span class="xref">UnitDisplacedBlackYoYInflationCouponPricerModel</span></div>
  </div>
  <div classs="implements">
    <h5>Implements</h5>
    <div><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.UnitDisplacedBlackYoYInflationCouponPricer</span>&gt;</div>
    <div><a class="xref" href="Cephei.Cell.ICell.html">ICell</a></div>
    <div><a class="xref" href="Cephei.Cell.ICellEvent.html">ICellEvent</a></div>
    <div><span class="xref">System.Collections.Generic.ICollection</span>&lt;<span class="xref">System.Collections.Generic.KeyValuePair</span>&lt;<span class="xref">string</span>,<a class="xref" href="Cephei.Cell.ICell.html">ICell</a>&gt;&gt;</div>
    <div><span class="xref">System.Collections.Generic.IDictionary</span>&lt;<span class="xref">string</span>,<a class="xref" href="Cephei.Cell.ICell.html">ICell</a>&gt;</div>
    <div><span class="xref">System.Collections.Generic.IEnumerable</span>&lt;<span class="xref">System.Collections.Generic.KeyValuePair</span>&lt;<span class="xref">string</span>,<a class="xref" href="Cephei.Cell.ICell.html">ICell</a>&gt;&gt;</div>
    <div><span class="xref">System.Collections.Generic.IReadOnlyCollection</span>&lt;<span class="xref">System.Collections.Generic.KeyValuePair</span>&lt;<span class="xref">string</span>,<a class="xref" href="Cephei.Cell.ICell.html">ICell</a>&gt;&gt;</div>
    <div><span class="xref">System.Collections.Generic.IReadOnlyDictionary</span>&lt;<span class="xref">string</span>,<a class="xref" href="Cephei.Cell.ICell.html">ICell</a>&gt;</div>
    <div><span class="xref">System.Collections.ICollection</span></div>
    <div><span class="xref">System.Collections.IDictionary</span></div>
    <div><span class="xref">System.Collections.IEnumerable</span></div>
    <div><span class="xref">System.IObservable</span>&lt;<a class="xref" href="Cephei.Cell.ICell.html">ICell</a>&gt;</div>
    <div><span class="xref">System.IObservable</span>&lt;<a class="xref" href="Cephei.Cell.ISession.html">ISession</a> * <a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.UnitDisplacedBlackYoYInflationCouponPricer</span>&gt; * <a class="xref" href="Cephei.Cell.CellEvent.html">CellEvent</a> * <a class="xref" href="Cephei.Cell.ICell.html">ICell</a> * <span class="xref">System.DateTime</span>&gt;</div>
    <div><span class="xref">System.IObservable</span>&lt;<a class="xref" href="Cephei.Cell.ISession.html">ISession</a> * <a class="xref" href="Cephei.Cell.Model.html">Model</a> * <a class="xref" href="Cephei.Cell.CellEvent.html">CellEvent</a> * <a class="xref" href="Cephei.Cell.ICell.html">ICell</a> * <span class="xref">System.DateTime</span>&gt;</div>
    <div><span class="xref">System.IObservable</span>&lt;<span class="xref">QLNet.UnitDisplacedBlackYoYInflationCouponPricer</span>&gt;</div>
    <div><span class="xref">System.IObservable</span>&lt;<span class="xref">System.Collections.Generic.KeyValuePair</span>&lt;<a class="xref" href="Cephei.Cell.ISession.html">ISession</a>,<span class="xref">System.Collections.Generic.KeyValuePair</span>&lt;<span class="xref">string</span>,<a class="xref" href="Cephei.Cell.ICell.html">ICell</a>&gt;&gt;&gt;</div>
    <div><span class="xref">System.IObservable</span>&lt;<span class="xref">System.Collections.Generic.KeyValuePair</span>&lt;<a class="xref" href="Cephei.Cell.ISession.html">ISession</a>,<span class="xref">System.Collections.Generic.KeyValuePair</span>&lt;<span class="xref">string</span>,<span class="xref">QLNet.UnitDisplacedBlackYoYInflationCouponPricer</span>&gt;&gt;&gt;</div>
    <div><span class="xref">System.IObservable</span>&lt;<span class="xref">System.Collections.Generic.KeyValuePair</span>&lt;<span class="xref">string</span>,<span class="xref">decimal</span>&gt;&gt;</div>
    <div><span class="xref">System.IObservable</span>&lt;<span class="xref">System.Collections.Generic.KeyValuePair</span>&lt;<span class="xref">string</span>,<span class="xref">float</span>&gt;&gt;</div>
    <div><span class="xref">System.IObservable</span>&lt;<span class="xref">System.Collections.Generic.KeyValuePair</span>&lt;<span class="xref">string</span>,<span class="xref">int</span>&gt;&gt;</div>
    <div><span class="xref">System.IObserver</span>&lt;<span class="xref">QLNet.UnitDisplacedBlackYoYInflationCouponPricer</span>&gt;</div>
  </div>
  <div class="inheritedMembers">
    <h5>Inherited Members</h5>
    <div>
      <span class="xref">member Cephei.Cell.Generic.Model.Bind: Cephei.Cell.Generic.ICell&lt;'T&gt; -&gt; unit</span>
    </div>
    <div>
      <span class="xref">abstract member Cephei.Cell.Generic.Model.OnCompleted: unit -&gt; unit</span>
    </div>
    <div>
      <span class="xref">abstract member Cephei.Cell.Generic.Model.OnError: exn -&gt; unit</span>
    </div>
    <div>
      <span class="xref">abstract member Cephei.Cell.Generic.Model.OnNext: 'T -&gt; unit</span>
    </div>
    <div>
      <span class="xref">abstract member Cephei.Cell.Generic.Model.Subscribe: System.IObserver&lt;'T&gt; -&gt; System.IDisposable</span>
    </div>
    <div>
      <span class="xref">abstract member Cephei.Cell.Generic.Model.Subscribe: System.IObserver&lt;Cephei.Cell.ISession * Cephei.Cell.Generic.ICell&lt;'T&gt; * Cephei.Cell.CellEvent * Cephei.Cell.ICell * System.DateTime&gt; -&gt; System.IDisposable</span>
    </div>
    <div>
      <span class="xref">abstract member Cephei.Cell.Generic.Model.Subscribe: System.IObserver&lt;System.Collections.Generic.KeyValuePair&lt;Cephei.Cell.ISession,System.Collections.Generic.KeyValuePair&lt;string,'T&gt;&gt;&gt; -&gt; System.IDisposable</span>
    </div>
    <div>
      <span class="xref">abstract property Cephei.Cell.Generic.Model.Value: 'T</span>
    </div>
    <div>
      <span class="xref">member Cephei.Cell.Model.As: string -&gt; Cephei.Cell.Generic.ICell&lt;'T&gt;</span>
    </div>
    <div>
      <span class="xref">member Cephei.Cell.Model.Bind: unit -&gt; unit</span>
    </div>
    <div>
      <span class="xref">abstract property Cephei.Cell.Model.Box: obj</span>
    </div>
    <div>
      <span class="xref">abstract member Cephei.Cell.Model.Change: Cephei.Cell.CellChange</span>
    </div>
    <div>
      <span class="xref">member Cephei.Cell.Model.Create: Unit -&gt; 'T * string -&gt; Cephei.Cell.Generic.Cell&lt;'T&gt;</span>
    </div>
    <div>
      <span class="xref">member Cephei.Cell.Model.CreateValue: 'T * string -&gt; Cephei.Cell.Generic.Cell&lt;'T&gt;</span>
    </div>
    <div>
      <span class="xref">abstract property Cephei.Cell.Model.Dependants: System.Collections.Generic.IEnumerable&lt;Cephei.Cell.ICellEvent&gt;</span>
    </div>
    <div>
      <span class="xref">member Cephei.Cell.Model.Dispose: unit -&gt; unit</span>
    </div>
    <div>
      <span class="xref">member Cephei.Cell.Model.GetOrAdd: string * Cephei.Cell.ICell -&gt; Cephei.Cell.ICell</span>
    </div>
    <div>
      <span class="xref">abstract property Cephei.Cell.Model.HasFunction: bool</span>
    </div>
    <div>
      <span class="xref">abstract property Cephei.Cell.Model.HasValue: bool</span>
    </div>
    <div>
      <span class="xref">property Cephei.Cell.Model.Item: string -&gt; Cephei.Cell.ICell</span>
    </div>
    <div>
      <span class="xref">abstract property Cephei.Cell.Model.Mnemonic: string</span>
    </div>
    <div>
      <span class="xref">abstract member Cephei.Cell.Model.OnChange: Cephei.Cell.CellEvent * Cephei.Cell.ICellEvent * System.DateTime * Cephei.Cell.ISession -&gt; unit</span>
    </div>
    <div>
      <span class="xref">abstract property Cephei.Cell.Model.Parent: Cephei.Cell.ICell</span>
    </div>
    <div>
      <span class="xref">abstract member Cephei.Cell.Model.Subscribe: System.IObserver&lt;Cephei.Cell.ICell&gt; -&gt; System.IDisposable</span>
    </div>
    <div>
      <span class="xref">abstract member Cephei.Cell.Model.Subscribe: System.IObserver&lt;Cephei.Cell.ISession * Cephei.Cell.Model * Cephei.Cell.CellEvent * Cephei.Cell.ICell * System.DateTime&gt; -&gt; System.IDisposable</span>
    </div>
    <div>
      <span class="xref">abstract member Cephei.Cell.Model.Subscribe: System.IObserver&lt;System.Collections.Generic.KeyValuePair&lt;Cephei.Cell.ISession,System.Collections.Generic.KeyValuePair&lt;string,Cephei.Cell.ICell&gt;&gt;&gt; -&gt; System.IDisposable</span>
    </div>
    <div>
      <span class="xref">abstract member Cephei.Cell.Model.Subscribe: System.IObserver&lt;System.Collections.Generic.KeyValuePair&lt;string,decimal&gt;&gt; -&gt; System.IDisposable</span>
    </div>
    <div>
      <span class="xref">abstract member Cephei.Cell.Model.Subscribe: System.IObserver&lt;System.Collections.Generic.KeyValuePair&lt;string,float&gt;&gt; -&gt; System.IDisposable</span>
    </div>
    <div>
      <span class="xref">abstract member Cephei.Cell.Model.Subscribe: System.IObserver&lt;System.Collections.Generic.KeyValuePair&lt;string,int&gt;&gt; -&gt; System.IDisposable</span>
    </div>
    <div>
      <span class="xref">member Cephei.Cell.Model.TryAdd: string * Cephei.Cell.ICell -&gt; bool</span>
    </div>
    <div>
      <span class="xref">member Cephei.Cell.Model.TryRemove: string * Cephei.Cell.ICell byref -&gt; bool</span>
    </div>
    <div>
      <span class="xref">member Cephei.Cell.Model.TryUpdate: string * Cephei.Cell.ICell * Cephei.Cell.ICell -&gt; bool</span>
    </div>
    <div>
      <span class="xref">abstract member Cephei.Cell.Model.add_Change: Cephei.Cell.CellChange -&gt; unit</span>
    </div>
    <div>
      <span class="xref">abstract member Cephei.Cell.Model.remove_Change: Cephei.Cell.CellChange -&gt; unit</span>
    </div>
    <div>
      <span class="xref">member System.Collections.Concurrent.ConcurrentDictionary.AddOrUpdate: 'TKey * 'TValue * System.Func&lt;'TKey,'TValue,'TValue&gt; -&gt; 'TValue</span>
    </div>
    <div>
      <span class="xref">member System.Collections.Concurrent.ConcurrentDictionary.AddOrUpdate: 'TKey * System.Func&lt;'TKey,'TValue&gt; * System.Func&lt;'TKey,'TValue,'TValue&gt; -&gt; 'TValue</span>
    </div>
    <div>
      <span class="xref">abstract member System.Collections.Concurrent.ConcurrentDictionary.Clear: unit -&gt; unit</span>
    </div>
    <div>
      <span class="xref">abstract member System.Collections.Concurrent.ConcurrentDictionary.ContainsKey: 'TKey -&gt; bool</span>
    </div>
    <div>
      <span class="xref">abstract property System.Collections.Concurrent.ConcurrentDictionary.Count: int</span>
    </div>
    <div>
      <span class="xref">abstract member System.Collections.Concurrent.ConcurrentDictionary.GetEnumerator: unit -&gt; System.Collections.Generic.IEnumerator&lt;System.Collections.Generic.KeyValuePair&lt;'TKey,'TValue&gt;&gt;</span>
    </div>
    <div>
      <span class="xref">member System.Collections.Concurrent.ConcurrentDictionary.GetOrAdd: 'TKey * 'TValue -&gt; 'TValue</span>
    </div>
    <div>
      <span class="xref">member System.Collections.Concurrent.ConcurrentDictionary.GetOrAdd: 'TKey * System.Func&lt;'TKey,'TValue&gt; -&gt; 'TValue</span>
    </div>
    <div>
      <span class="xref">property System.Collections.Concurrent.ConcurrentDictionary.IsEmpty: bool</span>
    </div>
    <div>
      <span class="xref">abstract property System.Collections.Concurrent.ConcurrentDictionary.Item: 'TKey -&gt; 'TValue</span>
    </div>
    <div>
      <span class="xref">abstract property System.Collections.Concurrent.ConcurrentDictionary.Keys: System.Collections.Generic.ICollection&lt;'TKey&gt;</span>
    </div>
    <div>
      <span class="xref">member System.Collections.Concurrent.ConcurrentDictionary.ToArray: unit -&gt; System.Collections.Generic.KeyValuePair&lt;'TKey,'TValue&gt; []</span>
    </div>
    <div>
      <span class="xref">member System.Collections.Concurrent.ConcurrentDictionary.TryAdd: 'TKey * 'TValue -&gt; bool</span>
    </div>
    <div>
      <span class="xref">abstract member System.Collections.Concurrent.ConcurrentDictionary.TryGetValue: 'TKey * 'TValue byref -&gt; bool</span>
    </div>
    <div>
      <span class="xref">member System.Collections.Concurrent.ConcurrentDictionary.TryRemove: 'TKey * 'TValue byref -&gt; bool</span>
    </div>
    <div>
      <span class="xref">member System.Collections.Concurrent.ConcurrentDictionary.TryUpdate: 'TKey * 'TValue * 'TValue -&gt; bool</span>
    </div>
    <div>
      <span class="xref">abstract property System.Collections.Concurrent.ConcurrentDictionary.Values: System.Collections.Generic.ICollection&lt;'TValue&gt;</span>
    </div>
  </div>
  <h6><strong>Namespace</strong>: <a class="xref" href="Cephei.QL.html">Cephei.QL</a></h6>
  <h6><strong>Assembly</strong>: Cephei.QL.dll</h6>
  <h5 id="Cephei_QL_UnitDisplacedBlackYoYInflationCouponPricerModel_syntax">Syntax</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">[&lt;AutoSerializable(true)&gt;]
type UnitDisplacedBlackYoYInflationCouponPricerModel (capletVol:ICell&lt;Handle&lt;YoYOptionletVolatilitySurface&gt;&gt;)
    inherit Model&lt;UnitDisplacedBlackYoYInflationCouponPricer&gt;
    interface IDictionary&lt;string,ICell&gt;
    interface ICollection&lt;KeyValuePair&lt;string,ICell&gt;&gt;
    interface IReadOnlyDictionary&lt;string,ICell&gt;
    interface IReadOnlyCollection&lt;KeyValuePair&lt;string,ICell&gt;&gt;
    interface IEnumerable&lt;KeyValuePair&lt;string,ICell&gt;&gt;
    interface IDictionary
    interface ICollection
    interface IEnumerable
    interface IObservable&lt;ICell&gt;
    interface IObservable&lt;KeyValuePair&lt;ISession,KeyValuePair&lt;string,ICell&gt;&gt;&gt;
    interface IObservable&lt;ISession * Model * CellEvent * ICell * DateTime&gt;
    interface IObservable&lt;KeyValuePair&lt;string,float&gt;&gt;
    interface IObservable&lt;KeyValuePair&lt;string,int&gt;&gt;
    interface IObservable&lt;KeyValuePair&lt;string,decimal&gt;&gt;
    interface ICell&lt;UnitDisplacedBlackYoYInflationCouponPricer&gt;
    interface ICell
    interface ICellEvent
    interface IObservable&lt;UnitDisplacedBlackYoYInflationCouponPricer&gt;
    interface IObservable&lt;KeyValuePair&lt;ISession,KeyValuePair&lt;string,UnitDisplacedBlackYoYInflationCouponPricer&gt;&gt;&gt;
    interface IObservable&lt;ISession * ICell&lt;UnitDisplacedBlackYoYInflationCouponPricer&gt; * CellEvent * ICell * DateTime&gt;
    interface IObserver&lt;UnitDisplacedBlackYoYInflationCouponPricer&gt;</code></pre>
  </div>
  <h5 class="parameters">Parameters</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Name</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.Handle</span>&lt;<span class="xref">QLNet.YoYOptionletVolatilitySurface</span>&gt;&gt;</td>
        <td><span class="parametername">capletVol</span></td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <h3 id="constructors">Constructors
  </h3>
  
  
  <a id="Cephei_QL_UnitDisplacedBlackYoYInflationCouponPricerModel__ctor_" data-uid="Cephei.QL.UnitDisplacedBlackYoYInflationCouponPricerModel.#ctor*"></a>
  <h4 id="Cephei_QL_UnitDisplacedBlackYoYInflationCouponPricerModel__ctor_Cephei_Cell_Generic_ICell_QLNet_Handle_QLNet_YoYOptionletVolatilitySurface___" data-uid="Cephei.QL.UnitDisplacedBlackYoYInflationCouponPricerModel.#ctor(Cephei.Cell.Generic.ICell&lt;QLNet.Handle&lt;QLNet.YoYOptionletVolatilitySurface&gt;&gt;)">new: ICell&lt;Handle&lt;YoYOptionletVolatilitySurface&gt;&gt; -&gt; UnitDisplacedBlackYoYInflationCouponPricerModel</h4>
  <div class="markdown level1 summary"><p sourcefile="obj/api/Cephei.QL.UnitDisplacedBlackYoYInflationCouponPricerModel.yml" sourcestartlinenumber="1" sourceendlinenumber="1">Implicit constructor.</p>
</div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">new: capletVol:ICell&lt;Handle&lt;YoYOptionletVolatilitySurface&gt;&gt; -&gt; UnitDisplacedBlackYoYInflationCouponPricerModel</code></pre>
  </div>
  <h5 class="parameters">Parameters</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Name</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.Handle</span>&lt;<span class="xref">QLNet.YoYOptionletVolatilitySurface</span>&gt;&gt;</td>
        <td><span class="parametername">capletVol</span></td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <h5 class="returns">Returns</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.QL.UnitDisplacedBlackYoYInflationCouponPricerModel.html">UnitDisplacedBlackYoYInflationCouponPricerModel</a></td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <h3 id="properties">Properties
  </h3>
  
  
  <a id="Cephei_QL_UnitDisplacedBlackYoYInflationCouponPricerModel_capletVol_" data-uid="Cephei.QL.UnitDisplacedBlackYoYInflationCouponPricerModel.capletVol*"></a>
  <h4 id="Cephei_QL_UnitDisplacedBlackYoYInflationCouponPricerModel_capletVol_unit_" data-uid="Cephei.QL.UnitDisplacedBlackYoYInflationCouponPricerModel.capletVol(unit)">property capletVol: ICell&lt;Handle&lt;YoYOptionletVolatilitySurface&gt;&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property capletVol: ICell&lt;Handle&lt;YoYOptionletVolatilitySurface&gt;&gt; with get</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.Handle</span>&lt;<span class="xref">QLNet.YoYOptionletVolatilitySurface</span>&gt;&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_UnitDisplacedBlackYoYInflationCouponPricerModel_CapletVolatility_" data-uid="Cephei.QL.UnitDisplacedBlackYoYInflationCouponPricerModel.CapletVolatility*"></a>
  <h4 id="Cephei_QL_UnitDisplacedBlackYoYInflationCouponPricerModel_CapletVolatility_unit_" data-uid="Cephei.QL.UnitDisplacedBlackYoYInflationCouponPricerModel.CapletVolatility(unit)">property CapletVolatility: ICell&lt;Handle&lt;YoYOptionletVolatilitySurface&gt;&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property CapletVolatility: ICell&lt;Handle&lt;YoYOptionletVolatilitySurface&gt;&gt; with get</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.Handle</span>&lt;<span class="xref">QLNet.YoYOptionletVolatilitySurface</span>&gt;&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_UnitDisplacedBlackYoYInflationCouponPricerModel_SwapletPrice_" data-uid="Cephei.QL.UnitDisplacedBlackYoYInflationCouponPricerModel.SwapletPrice*"></a>
  <h4 id="Cephei_QL_UnitDisplacedBlackYoYInflationCouponPricerModel_SwapletPrice_unit_" data-uid="Cephei.QL.UnitDisplacedBlackYoYInflationCouponPricerModel.SwapletPrice(unit)">property SwapletPrice: ICell&lt;float&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property SwapletPrice: ICell&lt;float&gt; with get</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">float</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_UnitDisplacedBlackYoYInflationCouponPricerModel_SwapletRate_" data-uid="Cephei.QL.UnitDisplacedBlackYoYInflationCouponPricerModel.SwapletRate*"></a>
  <h4 id="Cephei_QL_UnitDisplacedBlackYoYInflationCouponPricerModel_SwapletRate_unit_" data-uid="Cephei.QL.UnitDisplacedBlackYoYInflationCouponPricerModel.SwapletRate(unit)">property SwapletRate: ICell&lt;float&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property SwapletRate: ICell&lt;float&gt; with get</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">float</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_UnitDisplacedBlackYoYInflationCouponPricerModel_Update_" data-uid="Cephei.QL.UnitDisplacedBlackYoYInflationCouponPricerModel.Update*"></a>
  <h4 id="Cephei_QL_UnitDisplacedBlackYoYInflationCouponPricerModel_Update_unit_" data-uid="Cephei.QL.UnitDisplacedBlackYoYInflationCouponPricerModel.Update(unit)">property Update: ICell&lt;UnitDisplacedBlackYoYInflationCouponPricer&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property Update: ICell&lt;UnitDisplacedBlackYoYInflationCouponPricer&gt; with get</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.UnitDisplacedBlackYoYInflationCouponPricer</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <h3 id="methods">Methods
  </h3>
  
  
  <a id="Cephei_QL_UnitDisplacedBlackYoYInflationCouponPricerModel_CapletPrice_" data-uid="Cephei.QL.UnitDisplacedBlackYoYInflationCouponPricerModel.CapletPrice*"></a>
  <h4 id="Cephei_QL_UnitDisplacedBlackYoYInflationCouponPricerModel_CapletPrice_Cephei_Cell_Generic_ICell_double__" data-uid="Cephei.QL.UnitDisplacedBlackYoYInflationCouponPricerModel.CapletPrice(Cephei.Cell.Generic.ICell&lt;double&gt;)">member CapletPrice: ICell&lt;double&gt; -&gt; ICell&lt;float&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">member CapletPrice: effectiveCap:ICell&lt;double&gt; -&gt; ICell&lt;float&gt;</code></pre>
  </div>
  <h5 class="parameters">Parameters</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Name</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">double</span>&gt;</td>
        <td><span class="parametername">effectiveCap</span></td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <h5 class="returns">Returns</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">float</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_UnitDisplacedBlackYoYInflationCouponPricerModel_CapletRate_" data-uid="Cephei.QL.UnitDisplacedBlackYoYInflationCouponPricerModel.CapletRate*"></a>
  <h4 id="Cephei_QL_UnitDisplacedBlackYoYInflationCouponPricerModel_CapletRate_Cephei_Cell_Generic_ICell_double__" data-uid="Cephei.QL.UnitDisplacedBlackYoYInflationCouponPricerModel.CapletRate(Cephei.Cell.Generic.ICell&lt;double&gt;)">member CapletRate: ICell&lt;double&gt; -&gt; ICell&lt;float&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">member CapletRate: effectiveCap:ICell&lt;double&gt; -&gt; ICell&lt;float&gt;</code></pre>
  </div>
  <h5 class="parameters">Parameters</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Name</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">double</span>&gt;</td>
        <td><span class="parametername">effectiveCap</span></td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <h5 class="returns">Returns</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">float</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_UnitDisplacedBlackYoYInflationCouponPricerModel_FloorletPrice_" data-uid="Cephei.QL.UnitDisplacedBlackYoYInflationCouponPricerModel.FloorletPrice*"></a>
  <h4 id="Cephei_QL_UnitDisplacedBlackYoYInflationCouponPricerModel_FloorletPrice_Cephei_Cell_Generic_ICell_double__" data-uid="Cephei.QL.UnitDisplacedBlackYoYInflationCouponPricerModel.FloorletPrice(Cephei.Cell.Generic.ICell&lt;double&gt;)">member FloorletPrice: ICell&lt;double&gt; -&gt; ICell&lt;float&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">member FloorletPrice: effectiveFloor:ICell&lt;double&gt; -&gt; ICell&lt;float&gt;</code></pre>
  </div>
  <h5 class="parameters">Parameters</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Name</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">double</span>&gt;</td>
        <td><span class="parametername">effectiveFloor</span></td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <h5 class="returns">Returns</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">float</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_UnitDisplacedBlackYoYInflationCouponPricerModel_FloorletRate_" data-uid="Cephei.QL.UnitDisplacedBlackYoYInflationCouponPricerModel.FloorletRate*"></a>
  <h4 id="Cephei_QL_UnitDisplacedBlackYoYInflationCouponPricerModel_FloorletRate_Cephei_Cell_Generic_ICell_double__" data-uid="Cephei.QL.UnitDisplacedBlackYoYInflationCouponPricerModel.FloorletRate(Cephei.Cell.Generic.ICell&lt;double&gt;)">member FloorletRate: ICell&lt;double&gt; -&gt; ICell&lt;float&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">member FloorletRate: effectiveFloor:ICell&lt;double&gt; -&gt; ICell&lt;float&gt;</code></pre>
  </div>
  <h5 class="parameters">Parameters</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Name</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">double</span>&gt;</td>
        <td><span class="parametername">effectiveFloor</span></td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <h5 class="returns">Returns</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">float</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_UnitDisplacedBlackYoYInflationCouponPricerModel_Initialize_" data-uid="Cephei.QL.UnitDisplacedBlackYoYInflationCouponPricerModel.Initialize*"></a>
  <h4 id="Cephei_QL_UnitDisplacedBlackYoYInflationCouponPricerModel_Initialize_Cephei_Cell_Generic_ICell_QLNet_InflationCoupon__" data-uid="Cephei.QL.UnitDisplacedBlackYoYInflationCouponPricerModel.Initialize(Cephei.Cell.Generic.ICell&lt;QLNet.InflationCoupon&gt;)">member Initialize: ICell&lt;InflationCoupon&gt; -&gt; ICell&lt;UnitDisplacedBlackYoYInflationCouponPricer&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">member Initialize: coupon:ICell&lt;InflationCoupon&gt; -&gt; ICell&lt;UnitDisplacedBlackYoYInflationCouponPricer&gt;</code></pre>
  </div>
  <h5 class="parameters">Parameters</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Name</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.InflationCoupon</span>&gt;</td>
        <td><span class="parametername">coupon</span></td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <h5 class="returns">Returns</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.UnitDisplacedBlackYoYInflationCouponPricer</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_UnitDisplacedBlackYoYInflationCouponPricerModel_RegisterWith_" data-uid="Cephei.QL.UnitDisplacedBlackYoYInflationCouponPricerModel.RegisterWith*"></a>
  <h4 id="Cephei_QL_UnitDisplacedBlackYoYInflationCouponPricerModel_RegisterWith_Cephei_Cell_Generic_ICell_QLNet_Callback__" data-uid="Cephei.QL.UnitDisplacedBlackYoYInflationCouponPricerModel.RegisterWith(Cephei.Cell.Generic.ICell&lt;QLNet.Callback&gt;)">member RegisterWith: ICell&lt;Callback&gt; -&gt; ICell&lt;UnitDisplacedBlackYoYInflationCouponPricer&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">member RegisterWith: handler:ICell&lt;Callback&gt; -&gt; ICell&lt;UnitDisplacedBlackYoYInflationCouponPricer&gt;</code></pre>
  </div>
  <h5 class="parameters">Parameters</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Name</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.Callback</span>&gt;</td>
        <td><span class="parametername">handler</span></td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <h5 class="returns">Returns</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.UnitDisplacedBlackYoYInflationCouponPricer</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_UnitDisplacedBlackYoYInflationCouponPricerModel_SetCapletVolatility_" data-uid="Cephei.QL.UnitDisplacedBlackYoYInflationCouponPricerModel.SetCapletVolatility*"></a>
  <h4 id="Cephei_QL_UnitDisplacedBlackYoYInflationCouponPricerModel_SetCapletVolatility_Cephei_Cell_Generic_ICell_QLNet_Handle_QLNet_YoYOptionletVolatilitySurface___" data-uid="Cephei.QL.UnitDisplacedBlackYoYInflationCouponPricerModel.SetCapletVolatility(Cephei.Cell.Generic.ICell&lt;QLNet.Handle&lt;QLNet.YoYOptionletVolatilitySurface&gt;&gt;)">member SetCapletVolatility: ICell&lt;Handle&lt;YoYOptionletVolatilitySurface&gt;&gt; -&gt; ICell&lt;UnitDisplacedBlackYoYInflationCouponPricer&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">member SetCapletVolatility: capletVol:ICell&lt;Handle&lt;YoYOptionletVolatilitySurface&gt;&gt; -&gt; ICell&lt;UnitDisplacedBlackYoYInflationCouponPricer&gt;</code></pre>
  </div>
  <h5 class="parameters">Parameters</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Name</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.Handle</span>&lt;<span class="xref">QLNet.YoYOptionletVolatilitySurface</span>&gt;&gt;</td>
        <td><span class="parametername">capletVol</span></td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <h5 class="returns">Returns</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.UnitDisplacedBlackYoYInflationCouponPricer</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_UnitDisplacedBlackYoYInflationCouponPricerModel_UnregisterWith_" data-uid="Cephei.QL.UnitDisplacedBlackYoYInflationCouponPricerModel.UnregisterWith*"></a>
  <h4 id="Cephei_QL_UnitDisplacedBlackYoYInflationCouponPricerModel_UnregisterWith_Cephei_Cell_Generic_ICell_QLNet_Callback__" data-uid="Cephei.QL.UnitDisplacedBlackYoYInflationCouponPricerModel.UnregisterWith(Cephei.Cell.Generic.ICell&lt;QLNet.Callback&gt;)">member UnregisterWith: ICell&lt;Callback&gt; -&gt; ICell&lt;UnitDisplacedBlackYoYInflationCouponPricer&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">member UnregisterWith: handler:ICell&lt;Callback&gt; -&gt; ICell&lt;UnitDisplacedBlackYoYInflationCouponPricer&gt;</code></pre>
  </div>
  <h5 class="parameters">Parameters</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Name</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.Callback</span>&gt;</td>
        <td><span class="parametername">handler</span></td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <h5 class="returns">Returns</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.UnitDisplacedBlackYoYInflationCouponPricer</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <h3 id="implements">Implements</h3>
  <div>
      <span class="xref">Cephei.Cell.Generic.ICell&lt;QLNet.UnitDisplacedBlackYoYInflationCouponPricer&gt;</span>
  </div>
  <div>
      <span class="xref">Cephei.Cell.ICell</span>
  </div>
  <div>
      <span class="xref">Cephei.Cell.ICellEvent</span>
  </div>
  <div>
      <span class="xref">System.Collections.Generic.ICollection&lt;System.Collections.Generic.KeyValuePair&lt;string,Cephei.Cell.ICell&gt;&gt;</span>
  </div>
  <div>
      <span class="xref">System.Collections.Generic.IDictionary&lt;string,Cephei.Cell.ICell&gt;</span>
  </div>
  <div>
      <span class="xref">System.Collections.Generic.IEnumerable&lt;System.Collections.Generic.KeyValuePair&lt;string,Cephei.Cell.ICell&gt;&gt;</span>
  </div>
  <div>
      <span class="xref">System.Collections.Generic.IReadOnlyCollection&lt;System.Collections.Generic.KeyValuePair&lt;string,Cephei.Cell.ICell&gt;&gt;</span>
  </div>
  <div>
      <span class="xref">System.Collections.Generic.IReadOnlyDictionary&lt;string,Cephei.Cell.ICell&gt;</span>
  </div>
  <div>
      <span class="xref">System.Collections.ICollection</span>
  </div>
  <div>
      <span class="xref">System.Collections.IDictionary</span>
  </div>
  <div>
      <span class="xref">System.Collections.IEnumerable</span>
  </div>
  <div>
      <span class="xref">System.IObservable&lt;Cephei.Cell.ICell&gt;</span>
  </div>
  <div>
      <span class="xref">System.IObservable&lt;Cephei.Cell.ISession * Cephei.Cell.Generic.ICell&lt;QLNet.UnitDisplacedBlackYoYInflationCouponPricer&gt; * Cephei.Cell.CellEvent * Cephei.Cell.ICell * System.DateTime&gt;</span>
  </div>
  <div>
      <span class="xref">System.IObservable&lt;Cephei.Cell.ISession * Cephei.Cell.Model * Cephei.Cell.CellEvent * Cephei.Cell.ICell * System.DateTime&gt;</span>
  </div>
  <div>
      <span class="xref">System.IObservable&lt;QLNet.UnitDisplacedBlackYoYInflationCouponPricer&gt;</span>
  </div>
  <div>
      <span class="xref">System.IObservable&lt;System.Collections.Generic.KeyValuePair&lt;Cephei.Cell.ISession,System.Collections.Generic.KeyValuePair&lt;string,Cephei.Cell.ICell&gt;&gt;&gt;</span>
  </div>
  <div>
      <span class="xref">System.IObservable&lt;System.Collections.Generic.KeyValuePair&lt;Cephei.Cell.ISession,System.Collections.Generic.KeyValuePair&lt;string,QLNet.UnitDisplacedBlackYoYInflationCouponPricer&gt;&gt;&gt;</span>
  </div>
  <div>
      <span class="xref">System.IObservable&lt;System.Collections.Generic.KeyValuePair&lt;string,decimal&gt;&gt;</span>
  </div>
  <div>
      <span class="xref">System.IObservable&lt;System.Collections.Generic.KeyValuePair&lt;string,float&gt;&gt;</span>
  </div>
  <div>
      <span class="xref">System.IObservable&lt;System.Collections.Generic.KeyValuePair&lt;string,int&gt;&gt;</span>
  </div>
  <div>
      <span class="xref">System.IObserver&lt;QLNet.UnitDisplacedBlackYoYInflationCouponPricer&gt;</span>
  </div>
</article>
          </div>
          
          <div class="hidden-sm col-md-2" role="complementary">
            <div class="sideaffix">
              <div class="contribution">
                <ul class="nav">
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
