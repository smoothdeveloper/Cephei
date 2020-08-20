(*
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
namespace Cephei.QL

open System
open Cephei.QL.Util
open Cephei.Cell
open Cephei.Cell.Generic
open System.Collections
open System.Collections.Generic
open QLNet
open Cephei.QLNetHelper

(* <summary>
  This implementation is based on MINPACK (<http://www.netlib.org/minpack>,
<http://www.netlib.org/cephes/linalg.tgz>) It has a built in fd scheme to compute the jacobian, which is used by default. If useCostFunctionsJacobian is true the corresponding method in the cost function of the problem is used instead. Note that the default implementation of the jacobian in CostFunction uses a central difference (oder 2, but requiring more function evaluations) compared to the forward difference implemented here (order 1).

  </summary> *)
[<AutoSerializable(true)>]
type LevenbergMarquardtModel
    () as this =
    inherit Model<LevenbergMarquardt> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _LevenbergMarquardt                        = cell (fun () -> new LevenbergMarquardt ())
    let _fcn                                       (m : ICell<int>) (n : ICell<int>) (x : ICell<Vector>) (iflag : ICell<int>)   
                                                   = cell (fun () -> _LevenbergMarquardt.Value.fcn(m.Value, n.Value, x.Value, iflag.Value))
    let _getInfo                                   = cell (fun () -> _LevenbergMarquardt.Value.getInfo())
    let _jacFcn                                    (m : ICell<int>) (n : ICell<int>) (x : ICell<Vector>) (iflag : ICell<int>)   
                                                   = cell (fun () -> _LevenbergMarquardt.Value.jacFcn(m.Value, n.Value, x.Value, iflag.Value))
    let _minimize                                  (P : ICell<Problem>) (endCriteria : ICell<EndCriteria>)   
                                                   = cell (fun () -> _LevenbergMarquardt.Value.minimize(P.Value, endCriteria.Value))
    do this.Bind(_LevenbergMarquardt)

(* 
    Externally visible/bindable properties
*)
    member this.Fcn                                m n x iflag   
                                                   = _fcn m n x iflag 
    member this.GetInfo                            = _getInfo
    member this.JacFcn                             m n x iflag   
                                                   = _jacFcn m n x iflag 
    member this.Minimize                           P endCriteria   
                                                   = _minimize P endCriteria 
(* <summary>
  This implementation is based on MINPACK (<http://www.netlib.org/minpack>,
<http://www.netlib.org/cephes/linalg.tgz>) It has a built in fd scheme to compute the jacobian, which is used by default. If useCostFunctionsJacobian is true the corresponding method in the cost function of the problem is used instead. Note that the default implementation of the jacobian in CostFunction uses a central difference (oder 2, but requiring more function evaluations) compared to the forward difference implemented here (order 1).

  </summary> *)
[<AutoSerializable(true)>]
type LevenbergMarquardtModel1
    ( epsfcn                                       : ICell<double>
    , xtol                                         : ICell<double>
    , gtol                                         : ICell<double>
    , useCostFunctionsJacobian                     : ICell<bool>
    ) as this =

    inherit Model<LevenbergMarquardt> ()
(*
    Parameters
*)
    let _epsfcn                                    = epsfcn
    let _xtol                                      = xtol
    let _gtol                                      = gtol
    let _useCostFunctionsJacobian                  = useCostFunctionsJacobian
(*
    Functions
*)
    let _LevenbergMarquardt                        = cell (fun () -> new LevenbergMarquardt (epsfcn.Value, xtol.Value, gtol.Value, useCostFunctionsJacobian.Value))
    let _fcn                                       (m : ICell<int>) (n : ICell<int>) (x : ICell<Vector>) (iflag : ICell<int>)   
                                                   = cell (fun () -> _LevenbergMarquardt.Value.fcn(m.Value, n.Value, x.Value, iflag.Value))
    let _getInfo                                   = cell (fun () -> _LevenbergMarquardt.Value.getInfo())
    let _jacFcn                                    (m : ICell<int>) (n : ICell<int>) (x : ICell<Vector>) (iflag : ICell<int>)   
                                                   = cell (fun () -> _LevenbergMarquardt.Value.jacFcn(m.Value, n.Value, x.Value, iflag.Value))
    let _minimize                                  (P : ICell<Problem>) (endCriteria : ICell<EndCriteria>)   
                                                   = cell (fun () -> _LevenbergMarquardt.Value.minimize(P.Value, endCriteria.Value))
    do this.Bind(_LevenbergMarquardt)

(* 
    Externally visible/bindable properties
*)
    member this.epsfcn                             = _epsfcn 
    member this.xtol                               = _xtol 
    member this.gtol                               = _gtol 
    member this.useCostFunctionsJacobian           = _useCostFunctionsJacobian 
    member this.Fcn                                m n x iflag   
                                                   = _fcn m n x iflag 
    member this.GetInfo                            = _getInfo
    member this.JacFcn                             m n x iflag   
                                                   = _jacFcn m n x iflag 
    member this.Minimize                           P endCriteria   
                                                   = _minimize P endCriteria 