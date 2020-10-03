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

  </summary> *)
[<AutoSerializable(true)>]
module JPYCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_JPYCurrency", Description="Create a JPYCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let JPYCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.JPYCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<JPYCurrency>) l

                let source = Helper.sourceFold "Fun.JPYCurrency" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<JPYCurrency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! currency name, e.g, "U.S. Dollar"
    *)
    [<ExcelFunction(Name="_JPYCurrency_code", Description="Create a JPYCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let JPYCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JPYCurrency",Description = "Reference to JPYCurrency")>] 
         jpycurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JPYCurrency = Helper.toCell<JPYCurrency> jpycurrency "JPYCurrency"  
                let builder () = withMnemonic mnemonic ((_JPYCurrency.cell :?> JPYCurrencyModel).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_JPYCurrency.source + ".Code") 
                                               [| _JPYCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JPYCurrency.cell
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
        ! Other information ! is this a usable instance?
    *)
    [<ExcelFunction(Name="_JPYCurrency_empty", Description="Create a JPYCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let JPYCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JPYCurrency",Description = "Reference to JPYCurrency")>] 
         jpycurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JPYCurrency = Helper.toCell<JPYCurrency> jpycurrency "JPYCurrency"  
                let builder () = withMnemonic mnemonic ((_JPYCurrency.cell :?> JPYCurrencyModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_JPYCurrency.source + ".Empty") 
                                               [| _JPYCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JPYCurrency.cell
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
    [<ExcelFunction(Name="_JPYCurrency_Equals", Description="Create a JPYCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let JPYCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JPYCurrency",Description = "Reference to JPYCurrency")>] 
         jpycurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JPYCurrency = Helper.toCell<JPYCurrency> jpycurrency "JPYCurrency"  
                let _o = Helper.toCell<Object> o "o" 
                let builder () = withMnemonic mnemonic ((_JPYCurrency.cell :?> JPYCurrencyModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_JPYCurrency.source + ".Equals") 
                                               [| _JPYCurrency.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JPYCurrency.cell
                                ;  _o.cell
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
        ! currency used for triangulated exchange when required output format The format will be fed three positional parameters, namely, value, code, and symbol, in this order.
    *)
    [<ExcelFunction(Name="_JPYCurrency_format", Description="Create a JPYCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let JPYCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JPYCurrency",Description = "Reference to JPYCurrency")>] 
         jpycurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JPYCurrency = Helper.toCell<JPYCurrency> jpycurrency "JPYCurrency"  
                let builder () = withMnemonic mnemonic ((_JPYCurrency.cell :?> JPYCurrencyModel).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_JPYCurrency.source + ".Format") 
                                               [| _JPYCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JPYCurrency.cell
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
        ! fraction symbol, e.g, "Â¢"
    *)
    [<ExcelFunction(Name="_JPYCurrency_fractionsPerUnit", Description="Create a JPYCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let JPYCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JPYCurrency",Description = "Reference to JPYCurrency")>] 
         jpycurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JPYCurrency = Helper.toCell<JPYCurrency> jpycurrency "JPYCurrency"  
                let builder () = withMnemonic mnemonic ((_JPYCurrency.cell :?> JPYCurrencyModel).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_JPYCurrency.source + ".FractionsPerUnit") 
                                               [| _JPYCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JPYCurrency.cell
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
        ! symbol, e.g, "$"
    *)
    [<ExcelFunction(Name="_JPYCurrency_fractionSymbol", Description="Create a JPYCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let JPYCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JPYCurrency",Description = "Reference to JPYCurrency")>] 
         jpycurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JPYCurrency = Helper.toCell<JPYCurrency> jpycurrency "JPYCurrency"  
                let builder () = withMnemonic mnemonic ((_JPYCurrency.cell :?> JPYCurrencyModel).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_JPYCurrency.source + ".FractionSymbol") 
                                               [| _JPYCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JPYCurrency.cell
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
        Inspectors
    *)
    [<ExcelFunction(Name="_JPYCurrency_name", Description="Create a JPYCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let JPYCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JPYCurrency",Description = "Reference to JPYCurrency")>] 
         jpycurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JPYCurrency = Helper.toCell<JPYCurrency> jpycurrency "JPYCurrency"  
                let builder () = withMnemonic mnemonic ((_JPYCurrency.cell :?> JPYCurrencyModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_JPYCurrency.source + ".Name") 
                                               [| _JPYCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JPYCurrency.cell
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
        ! ISO 4217 three-letter code, e.g, "USD"
    *)
    [<ExcelFunction(Name="_JPYCurrency_numericCode", Description="Create a JPYCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let JPYCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JPYCurrency",Description = "Reference to JPYCurrency")>] 
         jpycurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JPYCurrency = Helper.toCell<JPYCurrency> jpycurrency "JPYCurrency"  
                let builder () = withMnemonic mnemonic ((_JPYCurrency.cell :?> JPYCurrencyModel).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_JPYCurrency.source + ".NumericCode") 
                                               [| _JPYCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JPYCurrency.cell
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
        ! number of fractionary parts in a unit, e.g, 100
    *)
    [<ExcelFunction(Name="_JPYCurrency_rounding", Description="Create a JPYCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let JPYCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JPYCurrency",Description = "Reference to JPYCurrency")>] 
         jpycurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JPYCurrency = Helper.toCell<JPYCurrency> jpycurrency "JPYCurrency"  
                let builder () = withMnemonic mnemonic ((_JPYCurrency.cell :?> JPYCurrencyModel).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source = Helper.sourceFold (_JPYCurrency.source + ".Rounding") 
                                               [| _JPYCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JPYCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<JPYCurrency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! ISO 4217 numeric code, e.g, "840"
    *)
    [<ExcelFunction(Name="_JPYCurrency_symbol", Description="Create a JPYCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let JPYCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JPYCurrency",Description = "Reference to JPYCurrency")>] 
         jpycurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JPYCurrency = Helper.toCell<JPYCurrency> jpycurrency "JPYCurrency"  
                let builder () = withMnemonic mnemonic ((_JPYCurrency.cell :?> JPYCurrencyModel).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_JPYCurrency.source + ".Symbol") 
                                               [| _JPYCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JPYCurrency.cell
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
    [<ExcelFunction(Name="_JPYCurrency_ToString", Description="Create a JPYCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let JPYCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JPYCurrency",Description = "Reference to JPYCurrency")>] 
         jpycurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JPYCurrency = Helper.toCell<JPYCurrency> jpycurrency "JPYCurrency"  
                let builder () = withMnemonic mnemonic ((_JPYCurrency.cell :?> JPYCurrencyModel).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_JPYCurrency.source + ".ToString") 
                                               [| _JPYCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JPYCurrency.cell
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
        ! rounding convention
    *)
    [<ExcelFunction(Name="_JPYCurrency_triangulationCurrency", Description="Create a JPYCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let JPYCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JPYCurrency",Description = "Reference to JPYCurrency")>] 
         jpycurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JPYCurrency = Helper.toCell<JPYCurrency> jpycurrency "JPYCurrency"  
                let builder () = withMnemonic mnemonic ((_JPYCurrency.cell :?> JPYCurrencyModel).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_JPYCurrency.source + ".TriangulationCurrency") 
                                               [| _JPYCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JPYCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<JPYCurrency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_JPYCurrency_Range", Description="Create a range of JPYCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let JPYCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the JPYCurrency")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<JPYCurrency> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<JPYCurrency>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<JPYCurrency>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<JPYCurrency>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"