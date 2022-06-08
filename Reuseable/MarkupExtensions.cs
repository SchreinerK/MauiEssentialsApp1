using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KsWare.Maui.Controls;

public static class MarkupExtensions {

	public static void AddRange(this IList<IView> childrenOfView, IEnumerable<IView> addChildren) {
		foreach (var child in addChildren) {
			childrenOfView.Add(child);
		}
	}
}
