﻿(*
Copyright (C) 2020 Cepheis Ltd (steve.channell@cepheis.com)

This file is part of Cephei.QL Project https://github.com/channell/Cephei

Cephei.QL is open source software based on QLNet  you can redistribute it and/or modify it
under the terms of the Cephei.QL license.  You should have received a
copy of the license along with this program; if not, license is
available at <https://github.com/channell/Cephei/LICENSE>.

QLNet is a based on QuantLib, a free-software/open-source library
for financial quantitative analysts and developers - http://quantlib.org/
The QuantLib license is available online at http://quantlib.org/license.shtml.

This program is distributed in the hope that it will be useful, but WITHOUT
ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
FOR A PARTICULAR PURPOSE.  See the license for more details.
*)
namespace Cephei.XL

open ExcelDna.Integration
open Cephei.Cell
open Cephei.Cell.Generic
open Cephei.QL
open System.Collections
open System
open System.Linq
open QLNet
open Cephei.XL.Helper

(* <summary>
  Unit Displaced Black-formula inflation cap/floor engine (standalone, i.e. no coupon pricer)
  </summary> *)
[<AutoSerializable(true)>]
module YoYInflationUnitDisplacedBlackCapFloorEngineFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_YoYInflationUnitDisplacedBlackCapFloorEngine", Description="Create a YoYInflationUnitDisplacedBlackCapFloorEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationUnitDisplacedBlackCapFloorEngine_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="index",Description = "Reference to index")>] 
         index : obj)
        ([<ExcelArgument(Name="vol",Description = "Reference to vol")>] 
         vol : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _index = Helper.toCell<YoYInflationIndex> index "index" 
                let _vol = Helper.toHandle<YoYOptionletVolatilitySurface> vol "vol" 
                let builder () = withMnemonic mnemonic (Fun.YoYInflationUnitDisplacedBlackCapFloorEngine 
                                                            _index.cell 
                                                            _vol.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YoYInflationUnitDisplacedBlackCapFloorEngine>) l

                let source = Helper.sourceFold "Fun.YoYInflationUnitDisplacedBlackCapFloorEngine" 
                                               [| _index.source
                                               ;  _vol.source
                                               |]
                let hash = Helper.hashFold 
                                [| _index.cell
                                ;  _vol.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YoYInflationUnitDisplacedBlackCapFloorEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"

    (*
        
    *)
    [<ExcelFunction(Name="_YoYInflationUnitDisplacedBlackCapFloorEngine_index", Description="Create a YoYInflationUnitDisplacedBlackCapFloorEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationUnitDisplacedBlackCapFloorEngine_index
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationUnitDisplacedBlackCapFloorEngine",Description = "Reference to YoYInflationUnitDisplacedBlackCapFloorEngine")>] 
         yoyinflationunitdisplacedblackcapfloorengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationUnitDisplacedBlackCapFloorEngine = Helper.toCell<YoYInflationUnitDisplacedBlackCapFloorEngine> yoyinflationunitdisplacedblackcapfloorengine "YoYInflationUnitDisplacedBlackCapFloorEngine"  
                let builder () = withMnemonic mnemonic ((_YoYInflationUnitDisplacedBlackCapFloorEngine.cell :?> YoYInflationUnitDisplacedBlackCapFloorEngineModel).Index
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YoYInflationIndex>) l

                let source = Helper.sourceFold (_YoYInflationUnitDisplacedBlackCapFloorEngine.source + ".Index") 
                                               [| _YoYInflationUnitDisplacedBlackCapFloorEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationUnitDisplacedBlackCapFloorEngine.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YoYInflationUnitDisplacedBlackCapFloorEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YoYInflationUnitDisplacedBlackCapFloorEngine_setVolatility", Description="Create a YoYInflationUnitDisplacedBlackCapFloorEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationUnitDisplacedBlackCapFloorEngine_setVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationUnitDisplacedBlackCapFloorEngine",Description = "Reference to YoYInflationUnitDisplacedBlackCapFloorEngine")>] 
         yoyinflationunitdisplacedblackcapfloorengine : obj)
        ([<ExcelArgument(Name="vol",Description = "Reference to vol")>] 
         vol : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationUnitDisplacedBlackCapFloorEngine = Helper.toCell<YoYInflationUnitDisplacedBlackCapFloorEngine> yoyinflationunitdisplacedblackcapfloorengine "YoYInflationUnitDisplacedBlackCapFloorEngine"  
                let _vol = Helper.toHandle<YoYOptionletVolatilitySurface> vol "vol" 
                let builder () = withMnemonic mnemonic ((_YoYInflationUnitDisplacedBlackCapFloorEngine.cell :?> YoYInflationUnitDisplacedBlackCapFloorEngineModel).SetVolatility
                                                            _vol.cell 
                                                       ) :> ICell
                let format (o : YoYInflationUnitDisplacedBlackCapFloorEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YoYInflationUnitDisplacedBlackCapFloorEngine.source + ".SetVolatility") 
                                               [| _YoYInflationUnitDisplacedBlackCapFloorEngine.source
                                               ;  _vol.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationUnitDisplacedBlackCapFloorEngine.cell
                                ;  _vol.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YoYInflationUnitDisplacedBlackCapFloorEngine_volatility", Description="Create a YoYInflationUnitDisplacedBlackCapFloorEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationUnitDisplacedBlackCapFloorEngine_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationUnitDisplacedBlackCapFloorEngine",Description = "Reference to YoYInflationUnitDisplacedBlackCapFloorEngine")>] 
         yoyinflationunitdisplacedblackcapfloorengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationUnitDisplacedBlackCapFloorEngine = Helper.toCell<YoYInflationUnitDisplacedBlackCapFloorEngine> yoyinflationunitdisplacedblackcapfloorengine "YoYInflationUnitDisplacedBlackCapFloorEngine"  
                let builder () = withMnemonic mnemonic ((_YoYInflationUnitDisplacedBlackCapFloorEngine.cell :?> YoYInflationUnitDisplacedBlackCapFloorEngineModel).Volatility
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YoYOptionletVolatilitySurface>>) l

                let source = Helper.sourceFold (_YoYInflationUnitDisplacedBlackCapFloorEngine.source + ".Volatility") 
                                               [| _YoYInflationUnitDisplacedBlackCapFloorEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationUnitDisplacedBlackCapFloorEngine.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YoYInflationUnitDisplacedBlackCapFloorEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_YoYInflationUnitDisplacedBlackCapFloorEngine_Range", Description="Create a range of YoYInflationUnitDisplacedBlackCapFloorEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationUnitDisplacedBlackCapFloorEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the YoYInflationUnitDisplacedBlackCapFloorEngine")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<YoYInflationUnitDisplacedBlackCapFloorEngine> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<YoYInflationUnitDisplacedBlackCapFloorEngine>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<YoYInflationUnitDisplacedBlackCapFloorEngine>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<YoYInflationUnitDisplacedBlackCapFloorEngine>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"