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
  Helper class for precomputed distributions
  </summary> *)
[<AutoSerializable(true)>]
module StatsHolderFunction =

    (*
        
    *)
    (*!! duplicate add function
    [<ExcelFunction(Name="_StatsHolder_add", Description="Create a StatsHolder",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let StatsHolder_add
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="StatsHolder",Description = "Reference to StatsHolder")>] 
         statsholder : obj)
        ([<ExcelArgument(Name="value",Description = "Reference to value")>] 
         value : obj)
        ([<ExcelArgument(Name="weight",Description = "Reference to weight")>] 
         weight : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _StatsHolder = Helper.toCell<StatsHolder> statsholder "StatsHolder"  
                let _value = Helper.toCell<double> value "value" 
                let _weight = Helper.toCell<double> weight "weight" 
                let builder () = withMnemonic mnemonic ((_StatsHolder.cell :?> StatsHolderModel).Add
                                                            _value.cell 
                                                            _weight.cell 
                                                       ) :> ICell
                let format (o : StatsHolder) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_StatsHolder.source + ".Add") 
                                               [| _StatsHolder.source
                                               ;  _value.source
                                               ;  _weight.source
                                               |]
                let hash = Helper.hashFold 
                                [| _StatsHolder.cell
                                ;  _value.cell
                                ;  _weight.cell
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
            *)
    (*
        
    *)
    [<ExcelFunction(Name="_StatsHolder_addSequence", Description="Create a StatsHolder",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let StatsHolder_addSequence
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="StatsHolder",Description = "Reference to StatsHolder")>] 
         statsholder : obj)
        ([<ExcelArgument(Name="data",Description = "Reference to data")>] 
         data : obj)
        ([<ExcelArgument(Name="weight",Description = "Reference to weight")>] 
         weight : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _StatsHolder = Helper.toCell<StatsHolder> statsholder "StatsHolder"  
                let _data = Helper.toCell<Generic.List<double>> data "data" 
                let _weight = Helper.toCell<Generic.List<double>> weight "weight" 
                let builder () = withMnemonic mnemonic ((_StatsHolder.cell :?> StatsHolderModel).AddSequence
                                                            _data.cell 
                                                            _weight.cell 
                                                       ) :> ICell
                let format (o : StatsHolder) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_StatsHolder.source + ".AddSequence") 
                                               [| _StatsHolder.source
                                               ;  _data.source
                                               ;  _weight.source
                                               |]
                let hash = Helper.hashFold 
                                [| _StatsHolder.cell
                                ;  _data.cell
                                ;  _weight.cell
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
    [<ExcelFunction(Name="_StatsHolder_errorEstimate", Description="Create a StatsHolder",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let StatsHolder_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="StatsHolder",Description = "Reference to StatsHolder")>] 
         statsholder : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _StatsHolder = Helper.toCell<StatsHolder> statsholder "StatsHolder"  
                let builder () = withMnemonic mnemonic ((_StatsHolder.cell :?> StatsHolderModel).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_StatsHolder.source + ".ErrorEstimate") 
                                               [| _StatsHolder.source
                                               |]
                let hash = Helper.hashFold 
                                [| _StatsHolder.cell
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
    [<ExcelFunction(Name="_StatsHolder_expectationValue", Description="Create a StatsHolder",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let StatsHolder_expectationValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="StatsHolder",Description = "Reference to StatsHolder")>] 
         statsholder : obj)
        ([<ExcelArgument(Name="f",Description = "Reference to f")>] 
         f : obj)
        ([<ExcelArgument(Name="inRange",Description = "Reference to inRange")>] 
         inRange : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _StatsHolder = Helper.toCell<StatsHolder> statsholder "StatsHolder"  
                let _f = Helper.toCell<Func<Generic.KeyValuePair<double,double>,double>> f "f" 
                let _inRange = Helper.toCell<Func<Generic.KeyValuePair<double,double>,bool>> inRange "inRange" 
                let builder () = withMnemonic mnemonic ((_StatsHolder.cell :?> StatsHolderModel).ExpectationValue
                                                            _f.cell 
                                                            _inRange.cell 
                                                       ) :> ICell
                let format (o : Generic.KeyValuePair<double,int>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_StatsHolder.source + ".ExpectationValue") 
                                               [| _StatsHolder.source
                                               ;  _f.source
                                               ;  _inRange.source
                                               |]
                let hash = Helper.hashFold 
                                [| _StatsHolder.cell
                                ;  _f.cell
                                ;  _inRange.cell
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
    [<ExcelFunction(Name="_StatsHolder_kurtosis", Description="Create a StatsHolder",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let StatsHolder_kurtosis
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="StatsHolder",Description = "Reference to StatsHolder")>] 
         statsholder : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _StatsHolder = Helper.toCell<StatsHolder> statsholder "StatsHolder"  
                let builder () = withMnemonic mnemonic ((_StatsHolder.cell :?> StatsHolderModel).Kurtosis
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_StatsHolder.source + ".Kurtosis") 
                                               [| _StatsHolder.source
                                               |]
                let hash = Helper.hashFold 
                                [| _StatsHolder.cell
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
    [<ExcelFunction(Name="_StatsHolder_max", Description="Create a StatsHolder",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let StatsHolder_max
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="StatsHolder",Description = "Reference to StatsHolder")>] 
         statsholder : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _StatsHolder = Helper.toCell<StatsHolder> statsholder "StatsHolder"  
                let builder () = withMnemonic mnemonic ((_StatsHolder.cell :?> StatsHolderModel).Max
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_StatsHolder.source + ".Max") 
                                               [| _StatsHolder.source
                                               |]
                let hash = Helper.hashFold 
                                [| _StatsHolder.cell
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
    [<ExcelFunction(Name="_StatsHolder_mean", Description="Create a StatsHolder",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let StatsHolder_mean
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="StatsHolder",Description = "Reference to StatsHolder")>] 
         statsholder : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _StatsHolder = Helper.toCell<StatsHolder> statsholder "StatsHolder"  
                let builder () = withMnemonic mnemonic ((_StatsHolder.cell :?> StatsHolderModel).Mean
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_StatsHolder.source + ".Mean") 
                                               [| _StatsHolder.source
                                               |]
                let hash = Helper.hashFold 
                                [| _StatsHolder.cell
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
    [<ExcelFunction(Name="_StatsHolder_min", Description="Create a StatsHolder",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let StatsHolder_min
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="StatsHolder",Description = "Reference to StatsHolder")>] 
         statsholder : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _StatsHolder = Helper.toCell<StatsHolder> statsholder "StatsHolder"  
                let builder () = withMnemonic mnemonic ((_StatsHolder.cell :?> StatsHolderModel).Min
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_StatsHolder.source + ".Min") 
                                               [| _StatsHolder.source
                                               |]
                let hash = Helper.hashFold 
                                [| _StatsHolder.cell
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
    [<ExcelFunction(Name="_StatsHolder_percentile", Description="Create a StatsHolder",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let StatsHolder_percentile
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="StatsHolder",Description = "Reference to StatsHolder")>] 
         statsholder : obj)
        ([<ExcelArgument(Name="percent",Description = "Reference to percent")>] 
         percent : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _StatsHolder = Helper.toCell<StatsHolder> statsholder "StatsHolder"  
                let _percent = Helper.toCell<double> percent "percent" 
                let builder () = withMnemonic mnemonic ((_StatsHolder.cell :?> StatsHolderModel).Percentile
                                                            _percent.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_StatsHolder.source + ".Percentile") 
                                               [| _StatsHolder.source
                                               ;  _percent.source
                                               |]
                let hash = Helper.hashFold 
                                [| _StatsHolder.cell
                                ;  _percent.cell
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
    [<ExcelFunction(Name="_StatsHolder_reset", Description="Create a StatsHolder",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let StatsHolder_reset
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="StatsHolder",Description = "Reference to StatsHolder")>] 
         statsholder : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _StatsHolder = Helper.toCell<StatsHolder> statsholder "StatsHolder"  
                let builder () = withMnemonic mnemonic ((_StatsHolder.cell :?> StatsHolderModel).Reset
                                                       ) :> ICell
                let format (o : StatsHolder) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_StatsHolder.source + ".Reset") 
                                               [| _StatsHolder.source
                                               |]
                let hash = Helper.hashFold 
                                [| _StatsHolder.cell
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
    [<ExcelFunction(Name="_StatsHolder_samples", Description="Create a StatsHolder",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let StatsHolder_samples
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="StatsHolder",Description = "Reference to StatsHolder")>] 
         statsholder : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _StatsHolder = Helper.toCell<StatsHolder> statsholder "StatsHolder"  
                let builder () = withMnemonic mnemonic ((_StatsHolder.cell :?> StatsHolderModel).Samples
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_StatsHolder.source + ".Samples") 
                                               [| _StatsHolder.source
                                               |]
                let hash = Helper.hashFold 
                                [| _StatsHolder.cell
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
    [<ExcelFunction(Name="_StatsHolder_skewness", Description="Create a StatsHolder",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let StatsHolder_skewness
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="StatsHolder",Description = "Reference to StatsHolder")>] 
         statsholder : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _StatsHolder = Helper.toCell<StatsHolder> statsholder "StatsHolder"  
                let builder () = withMnemonic mnemonic ((_StatsHolder.cell :?> StatsHolderModel).Skewness
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_StatsHolder.source + ".Skewness") 
                                               [| _StatsHolder.source
                                               |]
                let hash = Helper.hashFold 
                                [| _StatsHolder.cell
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
    [<ExcelFunction(Name="_StatsHolder_standardDeviation", Description="Create a StatsHolder",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let StatsHolder_standardDeviation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="StatsHolder",Description = "Reference to StatsHolder")>] 
         statsholder : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _StatsHolder = Helper.toCell<StatsHolder> statsholder "StatsHolder"  
                let builder () = withMnemonic mnemonic ((_StatsHolder.cell :?> StatsHolderModel).StandardDeviation
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_StatsHolder.source + ".StandardDeviation") 
                                               [| _StatsHolder.source
                                               |]
                let hash = Helper.hashFold 
                                [| _StatsHolder.cell
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
    [<ExcelFunction(Name="_StatsHolder1", Description="Create a StatsHolder",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let StatsHolder_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.StatsHolder1 () 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<StatsHolder>) l

                let source = Helper.sourceFold "Fun.StatsHolder1" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<StatsHolder> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        required for generics
    *)
    [<ExcelFunction(Name="_StatsHolder", Description="Create a StatsHolder",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let StatsHolder_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="mean",Description = "Reference to mean")>] 
         mean : obj)
        ([<ExcelArgument(Name="standardDeviation",Description = "Reference to standardDeviation")>] 
         standardDeviation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _mean = Helper.toCell<double> mean "mean" 
                let _standardDeviation = Helper.toCell<double> standardDeviation "standardDeviation" 
                let builder () = withMnemonic mnemonic (Fun.StatsHolder
                                                            _mean.cell 
                                                            _standardDeviation.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<StatsHolder>) l

                let source = Helper.sourceFold "Fun.StatsHolder" 
                                               [| _mean.source
                                               ;  _standardDeviation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _mean.cell
                                ;  _standardDeviation.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<StatsHolder> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_StatsHolder_variance", Description="Create a StatsHolder",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let StatsHolder_variance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="StatsHolder",Description = "Reference to StatsHolder")>] 
         statsholder : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _StatsHolder = Helper.toCell<StatsHolder> statsholder "StatsHolder"  
                let builder () = withMnemonic mnemonic ((_StatsHolder.cell :?> StatsHolderModel).Variance
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_StatsHolder.source + ".Variance") 
                                               [| _StatsHolder.source
                                               |]
                let hash = Helper.hashFold 
                                [| _StatsHolder.cell
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
    [<ExcelFunction(Name="_StatsHolder_weightSum", Description="Create a StatsHolder",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let StatsHolder_weightSum
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="StatsHolder",Description = "Reference to StatsHolder")>] 
         statsholder : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _StatsHolder = Helper.toCell<StatsHolder> statsholder "StatsHolder"  
                let builder () = withMnemonic mnemonic ((_StatsHolder.cell :?> StatsHolderModel).WeightSum
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_StatsHolder.source + ".WeightSum") 
                                               [| _StatsHolder.source
                                               |]
                let hash = Helper.hashFold 
                                [| _StatsHolder.cell
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
    [<ExcelFunction(Name="_StatsHolder_Range", Description="Create a range of StatsHolder",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let StatsHolder_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the StatsHolder")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<StatsHolder> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<StatsHolder>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<StatsHolder>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<StatsHolder>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"